using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.App.Forms;

public partial class frmDanhMucThuoc : Form
{
    private readonly BindingSource _bs = new();

    public frmDanhMucThuoc()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe);
        Theme.StyleStatus(lblTrangThai);
        txtTim.PlaceholderText = "Tìm thuốc cần sửa";

        dgvThuoc.AutoGenerateColumns = false;
        dgvThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvThuoc.Columns.AddRange(
            Cot(nameof(ThuocKetQua.TenThuoc), "Tên thuốc", 200),
            Cot(nameof(ThuocKetQua.HoatChat), "Hoạt chất - hàm lượng", 300),
            Cot(nameof(ThuocKetQua.GiaBan), "Giá bán", 80, "N0"),
            Cot(nameof(ThuocKetQua.ViTriKe), "Kệ", 60));
        dgvThuoc.DataSource = _bs;

        txtTim.TextChanged += (_, _) => { timerTim.Stop(); timerTim.Start(); };
        timerTim.Tick += async (_, _) => { timerTim.Stop(); await TaiLaiAsync(); };
        btnThem.Click += (_, _) => MoFormSua(0);
        btnSua.Click += (_, _) => { if (_bs.Current is ThuocKetQua t) MoFormSua(t.MaThuoc); };
        btnAn.Click += btnAn_Click;
        btnNhapCsv.Click += btnNhapCsv_Click;
        dgvThuoc.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && _bs.Current is ThuocKetQua t) MoFormSua(t.MaThuoc); };
    }

    private static DataGridViewTextBoxColumn Cot(string prop, string tieuDe, int trongSo, string? dinhDang = null)
    {
        var c = new DataGridViewTextBoxColumn { DataPropertyName = prop, HeaderText = tieuDe, FillWeight = trongSo };
        if (dinhDang != null) c.DefaultCellStyle.Format = dinhDang;
        return c;
    }

    private async Task TaiLaiAsync()
    {
        if (txtTim.Text.Trim().Length < 2) { _bs.DataSource = new List<ThuocKetQua>(); return; }
        var kq = await AppServices.Search.TimAsync(txtTim.Text, new BoLoc());
        _bs.DataSource = kq.Thuoc.ToList();
        lblTrangThai.Text = $"{kq.Thuoc.Count} thuốc";
    }

    private async void MoFormSua(int maThuoc)
    {
        using var f = new frmSuaThuoc(maThuoc);
        if (f.ShowDialog(this) == DialogResult.OK) await TaiLaiAsync();
    }

    private async void btnAn_Click(object? sender, EventArgs e)
    {
        if (_bs.Current is not ThuocKetQua t) return;
        if (MessageBox.Show($"Ẩn \"{t.TenThuoc}\" khỏi danh mục? Thuốc sẽ không còn hiện khi tìm kiếm và bán hàng.",
                "Ẩn thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        await AppServices.DanhMuc.AnAsync(t.MaThuoc);
        await TaiLaiAsync();
    }

    private async void btnNhapCsv_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "CSV (*.csv)|*.csv" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var (ok, loi) = await AppServices.DanhMuc.NhapCsvAsync(dlg.FileName);
            var thongBao = $"Nhập thành công {ok} thuốc.";
            if (loi.Count > 0) thongBao += $"\n\nCó {loi.Count} dòng lỗi:\n" + string.Join("\n", loi.Take(15));
            MessageBox.Show(thongBao, "Nhập CSV", MessageBoxButtons.OK,
                loi.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Không đọc được file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}