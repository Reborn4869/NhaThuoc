using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.App.Forms;

public partial class frmMain : Form
{
    public frmMain()
    {
        InitializeComponent();
        var nd = AppServices.NguoiDungHienTai!;
        lblNguoiDung.Text = $"{nd.HoTen} ({nd.VaiTro})";

        menu.BackColor = Theme.Primary;
        menu.ForeColor = Color.White;
        foreach (ToolStripItem item in menu.Items) item.ForeColor = Color.White;
        statusBar.BackColor = Theme.Background;

        mnuTimThuoc.Visible = AuthService.DuocPhep(nd.VaiTro, ChucNang.TimThuoc);
        mnuDanhMuc.Visible = AuthService.DuocPhep(nd.VaiTro, ChucNang.DanhMuc);
        mnuNhapKho.Visible = AuthService.DuocPhep(nd.VaiTro, ChucNang.NhapKho);
        mnuBanHang.Visible = AuthService.DuocPhep(nd.VaiTro, ChucNang.BanHang);
        mnuBaoCao.Visible = AuthService.DuocPhep(nd.VaiTro, ChucNang.BaoCao);

        mnuTimThuoc.Click += (_, _) => Mo<frmTimThuoc>();
        // Bỏ dấu // ở từng dòng dưới đây khi đã tạo form tương ứng (mục 10 đến 13):
        mnuDanhMuc.Click += (_, _) => Mo<frmDanhMucThuoc>();
        // mnuNhapKho.Click += (_, _) => Mo<frmNhapKho>();
        // mnuBanHang.Click += (_, _) => Mo<frmBanHang>();
        // mnuBaoCao.Click += (_, _) => Mo<frmBaoCao>();
        mnuDangXuat.Click += (_, _) => { AppServices.NguoiDungHienTai = null; Application.Restart(); };

        Load += (_, _) => Mo<frmTimThuoc>();
    }

    private void Mo<T>() where T : Form, new()
    {
        var f = MdiChildren.OfType<T>().FirstOrDefault();
        if (f == null)
        {
            f = new T { MdiParent = this, WindowState = FormWindowState.Maximized };
            f.Show();
        }
        else f.Activate();
    }
}