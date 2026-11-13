using System.ComponentModel;
using Microsoft.VisualBasic;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.App.Forms;

public partial class frmBanHang : Form
{
    private readonly BindingList<DongBan> _gio = new();
    private readonly BindingSource _bsGoiY = new();
    private CancellationTokenSource? _cts;

    public frmBanHang()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe);
        Theme.StyleStatus(lblTrangThai);
        txtTim.Font = Theme.Search;
        txtTim.PlaceholderText = "Gõ tên thuốc rồi nhấn Enter để thêm vào giỏ (F3)";
        txtThongTinDon.PlaceholderText = "Thông tin đơn thuốc: bác sĩ, số đơn (bắt buộc với thuốc kê đơn)";
        lblTong.Font = Theme.Title;
        lblTong.ForeColor = Theme.Primary;

        // kết quả tìm: chỉ thuốc còn hàng
        dgvGoiY.AutoGenerateColumns = false;
        dgvGoiY.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvGoiY.Columns.AddRange(
            Cot(nameof(ThuocKetQua.TenThuoc), "Tên thuốc", 160, false),
            Cot(nameof(ThuocKetQua.HoatChat), "Hoạt chất", 190, false),
            Cot(nameof(ThuocKetQua.GiaBan), "Giá", 70, false, "N0"),
            Cot(nameof(ThuocKetQua.TonKho), "Tồn", 60, false, "N0"));
        dgvGoiY.DataSource = _bsGoiY;
        dgvGoiY.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && _bsGoiY.Current is ThuocKetQua t) ThemVaoGio(t); };

        // giỏ hàng: chỉ cột số lượng sửa được
        dgvGio.AutoGenerateColumns = false;
        dgvGio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvGio.Columns.AddRange(
            Cot(nameof(DongBan.TenThuoc), "Thuốc", 200, false),
            Cot(nameof(DongBan.DonGia), "Đơn giá", 80, false, "N0"),
            Cot(nameof(DongBan.SoLuong), "Số lượng", 70, true, "N0"),
            Cot(nameof(DongBan.ThanhTien), "Thành tiền", 90, false, "N0"));
        dgvGio.DataSource = _gio;
        dgvGio.ReadOnly = false;
        dgvGio.EditMode = DataGridViewEditMode.EditOnEnter;
        dgvGio.DataError += (_, e) => e.ThrowException = false;   // gõ chữ vào ô số: bỏ qua
        dgvGio.CellEndEdit += (_, _) => DieuChinhSoLuong();

        txtTim.TextChanged += (_, _) => { timerTim.Stop(); timerTim.Start(); };
        timerTim.Tick += async (_, _) => { timerTim.Stop(); await TimAsync(); };
        numGiamGia.ValueChanged += (_, _) => CapNhatTong();
        btnXoaDong.Click += (_, _) => XoaDong();
        btnThanhToan.Click += btnThanhToan_Click;
        btnHuyHoaDon.Click += btnHuyHoaDon_Click;
        Shown += (_, _) => txtTim.Focus();
    }

    private static DataGridViewTextBoxColumn Cot(string prop, string tieuDe, int trongSo, bool choSua, string? dinhDang = null)
    {
        var c = new DataGridViewTextBoxColumn
        {
            DataPropertyName = prop,
            HeaderText = tieuDe,
            FillWeight = trongSo,
            ReadOnly = !choSua
        };
        if (dinhDang != null) c.DefaultCellStyle.Format = dinhDang;
        return c;
    }

    private async Task TimAsync()
    {
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        var ct = _cts.Token;
        if (txtTim.Text.Trim().Length < 2) { _bsGoiY.DataSource = new List<ThuocKetQua>(); return; }
        try
        {
            var kq = await AppServices.Search.TimAsync(txtTim.Text, new BoLoc { ConHang = true }, ct);
            if (ct.IsCancellationRequested) return;
            _bsGoiY.DataSource = kq.Thuoc.ToList();
            lblTrangThai.Text = kq.Thuoc.Count == 0 ? "Không có thuốc còn hàng phù hợp."
                : $"{kq.Thuoc.Count} thuốc còn hàng" + (kq.DaSuaThanh != null ? $" (kết quả cho \"{kq.DaSuaThanh}\")" : "");
        }
        catch (Exception) when (ct.IsCancellationRequested) { }
        catch (Exception ex) { lblTrangThai.Text = "Lỗi: " + ex.Message; }
    }

    private void ThemVaoGio(ThuocKetQua t)
    {
        var dong = _gio.FirstOrDefault(x => x.MaThuoc == t.MaThuoc);
        if (dong is null)
            _gio.Add(new DongBan { MaThuoc = t.MaThuoc, TenThuoc = t.TenThuoc, DonGia = t.GiaBan, KeDon = t.KeDon, TonKho = t.TonKho, SoLuong = 1 });
        else
            dong.SoLuong++;
        DieuChinhSoLuong();
        txtTim.Focus();
        txtTim.SelectAll();
    }

    // Không cho bán quá tồn hiện thấy (máy chủ vẫn kiểm tra lại khi thanh toán)
    private void DieuChinhSoLuong()
    {
        foreach (var d in _gio)
        {
            if (d.SoLuong < 1) d.SoLuong = 1;
            if (d.SoLuong > d.TonKho)
            {
                d.SoLuong = d.TonKho;
                lblTrangThai.Text = $"{d.TenThuoc} chỉ còn {d.TonKho} trong kho.";
            }
        }
        CapNhatTong();
    }

    private void XoaDong()
    {
        if (dgvGio.CurrentRow?.DataBoundItem is DongBan d) _gio.Remove(d);
        CapNhatTong();
    }

    private decimal TongThanhToan() => _gio.Sum(d => d.ThanhTien) - numGiamGia.Value;

    private void CapNhatTong()
    {
        dgvGio.Refresh();
        lblTong.Text = $"Thành tiền: {TongThanhToan():N0} đ";
        txtThongTinDon.Visible = _gio.Any(d => d.KeDon);
    }

    private async void btnThanhToan_Click(object? sender, EventArgs e)
    {
        var inDong = _gio.Select(d => new DongBan { MaThuoc = d.MaThuoc, TenThuoc = d.TenThuoc, DonGia = d.DonGia, SoLuong = d.SoLuong }).ToList();
        var hd = new HoaDonDto
        {
            MaND = AppServices.NguoiDungHienTai!.MaND,
            GiamGia = numGiamGia.Value,
            ThongTinDon = txtThongTinDon.Visible ? txtThongTinDon.Text : null,
            Dong = _gio.Select(d => new DongBan { MaThuoc = d.MaThuoc, TenThuoc = d.TenThuoc, SoLuong = d.SoLuong }).ToList()
        };
        var tong = TongThanhToan();
        var giamGia = numGiamGia.Value;

        btnThanhToan.Enabled = false;
        try
        {
            var ma = await AppServices.BanHang.LapHoaDonAsync(hd);
            _gio.Clear();
            numGiamGia.Value = 0;
            txtThongTinDon.Clear();
            CapNhatTong();
            await TimAsync();   // làm mới tồn kho trong danh sách

            if (MessageBox.Show($"Đã lập hóa đơn số {ma}, tổng thanh toán {tong:N0} đ.\n\nIn hóa đơn?",
                    "Bán hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                InHoaDon(ma, inDong, giamGia, tong);
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Chưa thanh toán được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Bán hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnThanhToan.Enabled = true;
        }
    }

    private async void btnHuyHoaDon_Click(object? sender, EventArgs e)
    {
        var nd = AppServices.NguoiDungHienTai!;
        if (nd.VaiTro is not (VaiTro.QuanTri or VaiTro.DuocSi))
        {
            MessageBox.Show("Chỉ dược sĩ hoặc quản trị mới được hủy hóa đơn.", "Không đủ quyền");
            return;
        }
        var s = Interaction.InputBox("Nhập số hóa đơn cần hủy:", "Hủy hóa đơn");
        if (!int.TryParse(s, out var ma)) return;
        try
        {
            var hd = await AppServices.BanHang.LayHoaDonAsync(ma);
            if (hd is null) { MessageBox.Show("Không có hóa đơn này.", "Hủy hóa đơn"); return; }
            if (MessageBox.Show($"Hủy hóa đơn {ma} ({hd.TongTien:N0} đ, lập lúc {hd.NgayLap:dd/MM/yyyy HH:mm})?\nSố lượng sẽ được trả lại kho.",
                    "Hủy hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            await AppServices.BanHang.HuyHoaDonAsync(ma, nd.MaND);
            MessageBox.Show("Đã hủy hóa đơn và hoàn kho.", "Hủy hóa đơn");
            await TimAsync();
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Không hủy được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Mở khung xem trước; trong hộp thoại in chọn máy in "Microsoft Print to PDF" để xuất PDF
    private void InHoaDon(int maHD, IReadOnlyList<DongBan> dong, decimal giamGia, decimal tong)
    {
        var doc = new System.Drawing.Printing.PrintDocument();
        doc.PrintPage += (_, e) =>
        {
            var g = e.Graphics!;
            using var f = new Font("Segoe UI", 10);
            using var fb = new Font("Segoe UI Semibold", 14);
            const float x = 40;
            float y = 40;
            g.DrawString("NHÀ THUỐC - HÓA ĐƠN BÁN LẺ", fb, Brushes.Black, x, y); y += 36;
            g.DrawString($"Số: {maHD}      Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", f, Brushes.Black, x, y); y += 30;
            foreach (var d in dong)
            {
                g.DrawString(d.TenThuoc, f, Brushes.Black, x, y);
                g.DrawString($"{d.SoLuong} x {d.DonGia:N0} = {d.ThanhTien:N0}", f, Brushes.Black, x + 320, y);
                y += 24;
            }
            y += 10;
            if (giamGia > 0) { g.DrawString($"Giảm giá: {giamGia:N0} đ", f, Brushes.Black, x, y); y += 24; }
            g.DrawString($"Tổng thanh toán: {tong:N0} đ", fb, Brushes.Black, x, y);
        };
        using var xemTruoc = new PrintPreviewDialog { Document = doc, Width = 900, Height = 700 };
        xemTruoc.ShowDialog(this);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.F3: txtTim.Focus(); txtTim.SelectAll(); return true;
            case Keys.F9: btnThanhToan.PerformClick(); return true;
            case Keys.Enter when txtTim.Focused:
                if (_bsGoiY.Current is ThuocKetQua t) ThemVaoGio(t);
                return true;
            case Keys.Down when txtTim.Focused: dgvGoiY.Focus(); return true;
            case Keys.Delete when dgvGio.Focused: XoaDong(); return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}