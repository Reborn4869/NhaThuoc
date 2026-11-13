using System.Data;
using ClosedXML.Excel;
using NhaThuoc.Core.Models;

namespace NhaThuoc.App.Forms;

public partial class frmBaoCao : Form
{
    // loại báo cáo, tên hiển thị, nhãn tham số (null: không dùng), giá trị mặc định, có dùng khoảng ngày không
    private static readonly (LoaiBaoCao Loai, string Ten, string? Nhan, int MacDinh, bool CoNgay)[] DanhSach =
    {
        (LoaiBaoCao.DoanhThuTheoNgay, "Doanh thu theo ngày", null, 0, true),
        (LoaiBaoCao.ThuocBanChay, "Thuốc bán chạy", "Số thuốc hiển thị", 20, true),
        (LoaiBaoCao.ThuocSapHetHan, "Thuốc sắp hết hạn", "Trong vòng (ngày)", 90, false),
        (LoaiBaoCao.ThuocSapHetHang, "Thuốc sắp hết hàng", "Tồn từ (đơn vị) trở xuống", 10, false),
        (LoaiBaoCao.TonKho, "Tồn kho và giá trị tồn", null, 0, false)
    };

    private DataTable? _bang;

    public frmBaoCao()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe);
        Theme.StyleStatus(lblTrangThai);

        var homNay = DateTime.Today;
        dtpTu.Value = new DateTime(homNay.Year, homNay.Month, 1);
        dtpDen.Value = homNay;

        cboLoai.DataSource = DanhSach.Select(x => x.Ten).ToList();
        cboLoai.SelectedIndexChanged += (_, _) => CapNhatThamSo();
        CapNhatThamSo();

        dgvBaoCao.CellFormatting += TomauHanDung;
        btnXem.Click += btnXem_Click;
        btnXuat.Click += btnXuat_Click;
    }

    private void CapNhatThamSo()
    {
        var l = DanhSach[cboLoai.SelectedIndex];
        lblThamSo.Visible = numThamSo.Visible = l.Nhan != null;
        lblThamSo.Text = l.Nhan ?? "";
        numThamSo.Value = l.MacDinh;
        lblTu.Visible = dtpTu.Visible = lblDen.Visible = dtpDen.Visible = l.CoNgay;
    }

    private async void btnXem_Click(object? sender, EventArgs e)
    {
        var l = DanhSach[cboLoai.SelectedIndex];
        btnXem.Enabled = false;
        try
        {
            _bang = await AppServices.BaoCao.LayAsync(l.Loai, dtpTu.Value, dtpDen.Value, (int)numThamSo.Value);
            dgvBaoCao.DataSource = _bang;
            foreach (DataGridViewColumn c in dgvBaoCao.Columns)
            {
                if (c.ValueType == typeof(decimal) || c.ValueType == typeof(int) || c.ValueType == typeof(long))
                {
                    c.DefaultCellStyle.Format = "N0";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (c.ValueType == typeof(DateTime))
                    c.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblTrangThai.Text = $"{_bang.Rows.Count} dòng - {l.Ten}";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lấy được báo cáo: " + ex.Message, "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnXem.Enabled = true;
        }
    }

    private void btnXuat_Click(object? sender, EventArgs e)
    {
        if (_bang == null || _bang.Rows.Count == 0)
        {
            MessageBox.Show("Chưa có dữ liệu để xuất. Hãy bấm \"Xem báo cáo\" trước.", "Xuất Excel");
            return;
        }
        using var dlg = new SaveFileDialog
        {
            Filter = "Excel (*.xlsx)|*.xlsx",
            FileName = $"{DanhSach[cboLoai.SelectedIndex].Ten} {DateTime.Now:yyyyMMdd}.xlsx"
        };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            using var wb = new XLWorkbook();
            wb.Worksheets.Add(_bang, "BaoCao");
            wb.SaveAs(dlg.FileName);
            lblTrangThai.Text = "Đã xuất: " + dlg.FileName;
        }
        catch (IOException)
        {
            MessageBox.Show("Không ghi được file. Có thể file đang mở trong Excel.", "Xuất Excel");
        }
    }

    // Báo cáo sắp hết hạn: lô đã hết hạn tô đỏ, còn dưới 30 ngày tô vàng đậm
    private void TomauHanDung(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.CellStyle == null) return;
        if (dgvBaoCao.Columns[e.ColumnIndex].HeaderText != "Số ngày còn" || e.Value is not int ngay) return;
        if (ngay < 0) { e.CellStyle.ForeColor = Theme.Danger; e.CellStyle.Font = Theme.Strong; }
        else if (ngay <= 30) { e.CellStyle.ForeColor = Theme.Warning; e.CellStyle.Font = Theme.Strong; }
    }
}