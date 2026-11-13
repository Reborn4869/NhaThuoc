using System.ComponentModel;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.App.Forms;

public partial class frmNhapKho : Form
{
    private readonly BindingList<DongNhap> _dong = new();
    private ThuocKetQua? _chon;

    public frmNhapKho()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe);
        Theme.StyleStatus(lblTrangThai);
        lblThuocChon.Font = Theme.Strong;
        txtTimThuoc.PlaceholderText = "Gõ tên thuốc hoặc hoạt chất để chọn";
        txtSoLo.PlaceholderText = "Số lô";
        txtGhiChu.PlaceholderText = "Ghi chú phiếu";

        dtpNSX.ShowCheckBox = true;
        dtpNSX.Checked = false;
        dtpHan.Value = DateTime.Today.AddYears(2);
        numSL.Maximum = 1_000_000;
        numGia.Maximum = 100_000_000;

        lstGoiY.DisplayMember = nameof(ThuocKetQua.TenThuoc);
        dgvDong.AutoGenerateColumns = false;
        dgvDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDong.Columns.AddRange(
            Cot(nameof(DongNhap.TenThuoc), "Thuốc", 220),
            Cot(nameof(DongNhap.SoLo), "Số lô", 90),
            Cot(nameof(DongNhap.NgaySX), "Ngày SX", 100, "dd/MM/yyyy"),
            Cot(nameof(DongNhap.HanDung), "Hạn dùng", 100, "dd/MM/yyyy"),
            Cot(nameof(DongNhap.SoLuong), "Số lượng", 80, "N0"),
            Cot(nameof(DongNhap.GiaNhap), "Giá nhập", 90, "N0"));
        dgvDong.DataSource = _dong;

        txtTimThuoc.TextChanged += (_, _) => { timerTim.Stop(); timerTim.Start(); };
        timerTim.Tick += async (_, _) => { timerTim.Stop(); await GoiYAsync(); };
        lstGoiY.SelectedIndexChanged += (_, _) =>
        {
            _chon = lstGoiY.SelectedItem as ThuocKetQua;
            lblThuocChon.Text = _chon?.TenThuoc ?? "(chưa chọn thuốc)";
        };
        btnThemDong.Click += btnThemDong_Click;
        btnXoaDong.Click += (_, _) => { if (dgvDong.CurrentRow?.DataBoundItem is DongNhap d) _dong.Remove(d); };
        btnLuuPhieu.Click += btnLuuPhieu_Click;
        Load += async (_, _) => await NapNccAsync();
    }

    private static DataGridViewTextBoxColumn Cot(string prop, string tieuDe, int trongSo, string? dinhDang = null)
    {
        var c = new DataGridViewTextBoxColumn { DataPropertyName = prop, HeaderText = tieuDe, FillWeight = trongSo };
        if (dinhDang != null) c.DefaultCellStyle.Format = dinhDang;
        return c;
    }

    private async Task NapNccAsync()
    {
        try { cboNCC.DataSource = await AppServices.Kho.LayNhaCungCapAsync(); }
        catch (Exception ex) { lblTrangThai.Text = "Không nạp được nhà cung cấp: " + ex.Message; }
    }

    private async Task GoiYAsync()
    {
        if (txtTimThuoc.Text.Trim().Length < 2) { lstGoiY.DataSource = null; return; }
        var kq = await AppServices.Search.TimAsync(txtTimThuoc.Text, new BoLoc());
        lstGoiY.DataSource = kq.Thuoc.Take(20).ToList();
    }

    private void btnThemDong_Click(object? sender, EventArgs e)
    {
        if (_chon is null)
        {
            MessageBox.Show("Hãy tìm và chọn một thuốc trong danh sách gợi ý.", "Chưa chọn thuốc");
            return;
        }
        _dong.Add(new DongNhap
        {
            MaThuoc = _chon.MaThuoc,
            TenThuoc = _chon.TenThuoc,
            SoLo = txtSoLo.Text.Trim(),
            NgaySX = dtpNSX.Checked ? dtpNSX.Value.Date : null,
            HanDung = dtpHan.Value.Date,
            SoLuong = (int)numSL.Value,
            GiaNhap = numGia.Value
        });
        txtSoLo.Clear();
        numSL.Value = 0;
        txtTimThuoc.Focus();
        txtTimThuoc.SelectAll();
    }

    private async void btnLuuPhieu_Click(object? sender, EventArgs e)
    {
        var pn = new PhieuNhapDto
        {
            MaNCC = cboNCC.SelectedItem is DanhMucItem n ? n.Ma : 0,
            MaND = AppServices.NguoiDungHienTai!.MaND,
            GhiChu = txtGhiChu.Text,
            Dong = _dong.ToList()
        };
        btnLuuPhieu.Enabled = false;
        try
        {
            var ma = await AppServices.Kho.NhapKhoAsync(pn);
            MessageBox.Show($"Đã lưu phiếu nhập số {ma}.", "Nhập kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _dong.Clear();
            txtGhiChu.Clear();
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Chưa lưu được phiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Nhập kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnLuuPhieu.Enabled = true;
        }
    }
}