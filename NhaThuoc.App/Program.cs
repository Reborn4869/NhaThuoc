namespace NhaThuoc.App;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            AppServices.Init();
            AppServices.Auth.KhoiTaoAdminAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không kết nối được CSDL:\n" + ex.Message, "Nhà thuốc",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using (var dangNhap = new Forms.frmDangNhap())
            if (dangNhap.ShowDialog() != DialogResult.OK) return;

        Application.Run(new Forms.frmMain());
    }
}