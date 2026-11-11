namespace NhaThuoc.App.Forms;

public partial class frmDangNhap : Form
{
    public frmDangNhap()
    {
        InitializeComponent();
        Theme.Apply(this);
        Theme.StyleHeader(pnlHeader, lblTieuDe);
        lblLoi.ForeColor = Theme.Danger;
        btnDangNhap.Click += btnDangNhap_Click;
    }

    private async void btnDangNhap_Click(object? sender, EventArgs e)
    {
        btnDangNhap.Enabled = false;
        lblLoi.Text = "";
        try
        {
            var nd = await AppServices.Auth.DangNhapAsync(txtTenDangNhap.Text, txtMatKhau.Text);
            if (nd is null)
            {
                lblLoi.Text = "Sai tên đăng nhập hoặc mật khẩu.";
                txtMatKhau.SelectAll();
                txtMatKhau.Focus();
                return;
            }
            AppServices.NguoiDungHienTai = nd;
            DialogResult = DialogResult.OK;   // đóng hộp thoại
        }
        catch (Exception ex)
        {
            lblLoi.Text = "Lỗi: " + ex.Message;
        }
        finally
        {
            btnDangNhap.Enabled = true;
        }
    }
}