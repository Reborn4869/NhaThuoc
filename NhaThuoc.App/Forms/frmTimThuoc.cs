using NhaThuoc.Core.Models;

namespace NhaThuoc.App.Forms;

public partial class frmTimThuoc : Form
{
    private CancellationTokenSource? _cts;
    private readonly BindingSource _bs = new();
    private bool _dangNap = true;

    public frmTimThuoc()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe, lblGoiY);
        Theme.StyleStatus(lblTrangThai);
        txtTimKiem.Font = Theme.Search;
        txtTimKiem.PlaceholderText = "Gõ tên thuốc hoặc hoạt chất";

        TaoCot();
        dgvKetQua.DataSource = _bs;

        timerTim.Tick += async (_, _) => { timerTim.Stop(); await ThucHienTimAsync(); };
        txtTimKiem.TextChanged += (_, _) => KhoiDongLaiTimer();
        chkNhieuHoatChat.CheckedChanged += (_, _) => KhoiDongLaiTimer();
        numGiaMin.ValueChanged += (_, _) => KhoiDongLaiTimer();
        numGiaMax.ValueChanged += (_, _) => KhoiDongLaiTimer();
        foreach (var cbo in new[] { cboNhom, cboDang, cboKeDon, cboTonKho, cboSapXep, cboCheDo })
            cbo.SelectedIndexChanged += (_, _) => KhoiDongLaiTimer();

        btnThayThe.Click += btnThayThe_Click;
        btnChiTiet.Click += btnChiTiet_Click;
        dgvKetQua.CellFormatting += TomauHang;
        Load += async (_, _) => await NapDanhMucAsync();
    }

    private void KhoiDongLaiTimer()
    {
        if (_dangNap) return;
        timerTim.Stop();
        timerTim.Start();
    }

    private void TaoCot()
    {
        dgvKetQua.AutoGenerateColumns = false;
        dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvKetQua.Columns.AddRange(
            Cot(nameof(ThuocKetQua.TenThuoc), "Tên thuốc", 200),
            Cot(nameof(ThuocKetQua.HoatChat), "Hoạt chất - hàm lượng", 280),
            Cot(nameof(ThuocKetQua.DonViTinh), "ĐVT", 50),
            Cot(nameof(ThuocKetQua.GiaBan), "Giá bán", 80, "N0", phai: true),
            Cot(nameof(ThuocKetQua.TonKho), "Tồn", 80, phai: true),
            Cot(nameof(ThuocKetQua.HanGanNhat), "Hạn gần nhất", 100, "dd/MM/yyyy"),
            Cot(nameof(ThuocKetQua.ViTriKe), "Kệ", 55),
            Cot(nameof(ThuocKetQua.KeDon), "Kê đơn", 70),
            Cot(nameof(ThuocKetQua.KieuKhop), "Khớp theo", 90));
    }

    private static DataGridViewTextBoxColumn Cot(string prop, string tieuDe, int trongSo,
        string? dinhDang = null, bool phai = false)
    {
        var c = new DataGridViewTextBoxColumn
        {
            DataPropertyName = prop,
            HeaderText = tieuDe,
            Name = "col" + prop,
            FillWeight = trongSo,
            MinimumWidth = 50
        };
        if (dinhDang != null) c.DefaultCellStyle.Format = dinhDang;
        if (phai) c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        return c;
    }

    private async Task NapDanhMucAsync()
    {
        try
        {
            _dangNap = true;
            var nhom = await AppServices.Thuoc.LayNhomAsync();
            nhom.Insert(0, new DanhMucItem(0, "Tất cả nhóm"));
            cboNhom.DataSource = nhom;

            var dang = await AppServices.Thuoc.LayDangBaoCheAsync();
            dang.Insert(0, new DanhMucItem(0, "Tất cả dạng"));
            cboDang.DataSource = dang;

            cboKeDon.Items.AddRange(new object[] { "Kê đơn: tất cả", "Chỉ thuốc kê đơn", "Chỉ không kê đơn" });
            cboTonKho.Items.AddRange(new object[] { "Tồn kho: tất cả", "Còn hàng", "Hết hàng" });
            cboSapXep.Items.AddRange(new object[] { "Độ phù hợp", "Giá tăng dần", "Hạn dùng gần nhất", "Tồn kho nhiều nhất" });
            cboCheDo.Items.AddRange(new object[] { "Có đủ tất cả (AND)", "Có ít nhất một (OR)" });
            cboKeDon.SelectedIndex = cboTonKho.SelectedIndex = cboSapXep.SelectedIndex = cboCheDo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblTrangThai.Text = "Không kết nối được CSDL: " + ex.Message;
        }
        finally
        {
            _dangNap = false;
            txtTimKiem.Focus();
        }
    }

    private BoLoc TaoBoLoc() => new()
    {
        MaNhom = cboNhom.SelectedItem is DanhMucItem { Ma: > 0 } n ? n.Ma : null,
        MaDang = cboDang.SelectedItem is DanhMucItem { Ma: > 0 } d ? d.Ma : null,
        KeDon = cboKeDon.SelectedIndex switch { 1 => true, 2 => false, _ => null },
        ConHang = cboTonKho.SelectedIndex switch { 1 => true, 2 => false, _ => null },
        GiaMin = numGiaMin.Value > 0 ? numGiaMin.Value : null,
        GiaMax = numGiaMax.Value > 0 ? numGiaMax.Value : null,
        SapXep = cboSapXep.SelectedIndex switch { 1 => "gia", 2 => "hansd", 3 => "tonkho", _ => "phuhop" }
    };

    private async Task ThucHienTimAsync()
    {
        _cts?.Cancel();                    // bỏ truy vấn cũ nếu còn đang chạy
        _cts = new CancellationTokenSource();
        var ct = _cts.Token;

        var tuKhoa = txtTimKiem.Text.Trim();
        if (tuKhoa.Length < 2)
        {
            _bs.DataSource = new List<ThuocKetQua>();
            lblTrangThai.Text = "Nhập ít nhất 2 ký tự.";
            return;
        }

        var sw = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            List<ThuocKetQua> ds;
            string? sua = null;
            if (chkNhieuHoatChat.Checked)
                ds = await AppServices.Search.TimTheoHoatChatAsync(tuKhoa, cboCheDo.SelectedIndex == 0, ct);
            else
            {
                var kq = await AppServices.Search.TimAsync(tuKhoa, TaoBoLoc(), ct);
                ds = kq.Thuoc.ToList();
                sua = kq.DaSuaThanh;
            }
            if (ct.IsCancellationRequested) return;

            _bs.DataSource = ds;
            lblTrangThai.Text = ds.Count == 0
                ? "Không tìm thấy thuốc phù hợp."
                : $"{ds.Count} kết quả ({sw.ElapsedMilliseconds} ms)"
                  + (sua != null ? $" - đang hiển thị kết quả cho \"{sua}\"" : "");
        }
        catch (Exception) when (ct.IsCancellationRequested) { /* bị thay bằng lần tìm mới */ }
        catch (Exception ex)
        {
            lblTrangThai.Text = "Lỗi: " + ex.Message;
        }
    }

    // Tô màu theo ý nghĩa: hết hàng đỏ, sắp hết vàng, còn nhiều xanh; cận date vàng đậm; kê đơn đỏ.
    private void TomauHang(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        var st = e.CellStyle;
        if (st == null || e.RowIndex < 0 || dgvKetQua.Rows[e.RowIndex].DataBoundItem is not ThuocKetQua t) return;

        st.ForeColor = t.TonKho == 0 ? Theme.TextMuted : Theme.Text;   // thuốc hết hàng: cả dòng xám

        switch (dgvKetQua.Columns[e.ColumnIndex].Name)
        {
            case "colTonKho":
                e.Value = t.TonKho == 0 ? "Hết hàng" : t.TonKho.ToString("N0");
                st.ForeColor = t.TonKho == 0 ? Theme.Danger : t.TonKho <= 10 ? Theme.Warning : Theme.Success;
                st.Font = Theme.Strong;
                e.FormattingApplied = true;
                break;
            case "colHanGanNhat":
                if (t.TonKho > 0 && t.HanGanNhat is { } h && (h - DateTime.Today).TotalDays <= 90)
                {
                    st.ForeColor = Theme.Warning;
                    st.Font = Theme.Strong;
                }
                break;
            case "colKeDon":
                e.Value = t.KeDon ? "Kê đơn" : "";
                st.ForeColor = Theme.Danger;
                e.FormattingApplied = true;
                break;
        }
    }

    private async void btnThayThe_Click(object? sender, EventArgs e)
    {
        if (_bs.Current is not ThuocKetQua t) return;
        var ds = await AppServices.Search.ThuocThayTheAsync(t.MaThuoc);
        _bs.DataSource = ds;
        lblTrangThai.Text = ds.Count == 0
            ? $"Không có thuốc nào cùng hoạt chất với {t.TenThuoc}."
            : $"{ds.Count} thuốc cùng hoạt chất với {t.TenThuoc} (cùng hàm lượng xếp trước). Nhấn Esc để quay lại.";
    }

    private async void btnChiTiet_Click(object? sender, EventArgs e)
    {
        if (_bs.Current is not ThuocKetQua t) return;
        var ct = await AppServices.Thuoc.LayChiTietAsync(t.MaThuoc);
        MessageBox.Show(
            $"{t.TenThuoc}\n\nCông dụng: {ct?.CongDung}\nChống chỉ định: {ct?.ChongChiDinh}\nBảo quản: {ct?.BaoQuan}\n\n" +
            "Thông tin chỉ mang tính tham khảo, không thay thế tư vấn của dược sĩ.",
            "Chi tiết thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.F3: txtTimKiem.Focus(); txtTimKiem.SelectAll(); return true;
            case Keys.F4: btnThayThe.PerformClick(); return true;
            case Keys.F5: btnChiTiet.PerformClick(); return true;
            case Keys.Escape: _ = ThucHienTimAsync(); return true;
            case Keys.Down when txtTimKiem.Focused: dgvKetQua.Focus(); return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}