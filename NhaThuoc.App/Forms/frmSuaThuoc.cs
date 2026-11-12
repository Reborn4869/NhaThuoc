using Microsoft.VisualBasic;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.App.Forms;

public partial class frmSuaThuoc : Form
{
    private ThuocEdit _t = new();
    private readonly int _maThuoc;
    private DataGridViewComboBoxColumn _colHc = null!;

    public frmSuaThuoc(int maThuoc)
    {
        _maThuoc = maThuoc;
        InitializeComponent();
        Theme.Apply(this);

        // bảng hoạt chất: Theme tắt chỉnh sửa, ta bật lại
        dgvHoatChat.ReadOnly = false;
        dgvHoatChat.AllowUserToAddRows = true;
        dgvHoatChat.AllowUserToDeleteRows = true;
        dgvHoatChat.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dgvHoatChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHoatChat.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHamLuong", HeaderText = "Hàm lượng (ví dụ 500 mg)", FillWeight = 40 });

        btnLuu.Click += btnLuu_Click;
        btnHoatChatMoi.Click += btnHoatChatMoi_Click;
        Load += async (_, _) => await NapAsync();
    }

    private async Task NapHoatChatAsync()
    {
        var ds = await AppServices.DanhMuc.LayHoatChatAsync();
        if (_colHc != null) dgvHoatChat.Columns.Remove(_colHc);
        _colHc = new DataGridViewComboBoxColumn
        {
            Name = "colHoatChat",
            HeaderText = "Hoạt chất",
            FillWeight = 60,
            FlatStyle = FlatStyle.Flat,
            DataSource = ds,
            DisplayMember = "Ten",
            ValueMember = "Ma"
        };
        dgvHoatChat.Columns.Insert(0, _colHc);
    }

    private async Task NapAsync()
    {
        var nhom = await AppServices.Thuoc.LayNhomAsync();
        nhom.Insert(0, new DanhMucItem(0, "(Chưa phân nhóm)"));
        cboNhom.DataSource = nhom;
        var dang = await AppServices.Thuoc.LayDangBaoCheAsync();
        dang.Insert(0, new DanhMucItem(0, "(Chưa chọn dạng)"));
        cboDang.DataSource = dang;
        await NapHoatChatAsync();

        if (_maThuoc == 0) { Text = "Thêm thuốc"; return; }
        _t = await AppServices.DanhMuc.LayAsync(_maThuoc) ?? new ThuocEdit();
        txtTen.Text = _t.TenThuoc;
        txtMaVach.Text = _t.MaVach;
        cboNhom.SelectedItem = nhom.FirstOrDefault(x => x.Ma == (_t.MaNhom ?? 0));
        cboDang.SelectedItem = dang.FirstOrDefault(x => x.Ma == (_t.MaDang ?? 0));
        chkKeDon.Checked = _t.KeDon;
        numGia.Value = _t.GiaBan;
        txtDvt.Text = _t.DonViTinh;
        txtKe.Text = _t.ViTriKe;
        txtCongDung.Text = _t.CongDung;
        txtChongChiDinh.Text = _t.ChongChiDinh;
        txtBaoQuan.Text = _t.BaoQuan;
        foreach (var h in _t.HoatChat) dgvHoatChat.Rows.Add(h.MaHC, h.HamLuong);
    }

    private async void btnLuu_Click(object? sender, EventArgs e)
    {
        try
        {
            _t.TenThuoc = txtTen.Text;
            _t.MaVach = string.IsNullOrWhiteSpace(txtMaVach.Text) ? null : txtMaVach.Text.Trim();
            _t.MaNhom = cboNhom.SelectedItem is DanhMucItem { Ma: > 0 } n ? n.Ma : null;
            _t.MaDang = cboDang.SelectedItem is DanhMucItem { Ma: > 0 } d ? d.Ma : null;
            _t.KeDon = chkKeDon.Checked;
            _t.GiaBan = numGia.Value;
            _t.DonViTinh = txtDvt.Text;
            _t.ViTriKe = txtKe.Text;
            _t.CongDung = txtCongDung.Text;
            _t.ChongChiDinh = txtChongChiDinh.Text;
            _t.BaoQuan = txtBaoQuan.Text;
            _t.HoatChat = dgvHoatChat.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && r.Cells["colHoatChat"].Value is int)
                .Select(r => new HoatChatDong((int)r.Cells["colHoatChat"].Value!,
                    string.IsNullOrWhiteSpace(r.Cells["colHamLuong"].Value as string)
                        ? null : ((string)r.Cells["colHamLuong"].Value!).Trim()))
                .ToList();

            await AppServices.DanhMuc.LuuAsync(_t);
            DialogResult = DialogResult.OK;
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Chưa lưu được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async void btnHoatChatMoi_Click(object? sender, EventArgs e)
    {
        var ten = Interaction.InputBox("Tên hoạt chất mới:", "Thêm hoạt chất");
        if (string.IsNullOrWhiteSpace(ten)) return;
        var alias = Interaction.InputBox("Tên khác, cách nhau bằng dấu phẩy (có thể bỏ trống):", "Tên đồng nghĩa");
        try
        {
            await AppServices.DanhMuc.ThemHoatChatAsync(ten, alias.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            await NapHoatChatAsync();   // nạp lại danh sách để chọn được ngay
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Chưa thêm được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}