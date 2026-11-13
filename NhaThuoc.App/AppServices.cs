using Microsoft.Extensions.Configuration;
using NhaThuoc.Core.Services;
using NhaThuoc.Data.Repositories;
using NhaThuoc.Core.Models;

using DocumentFormat.OpenXml.Spreadsheet;
namespace NhaThuoc.App;
internal static class AppServices
{
    public static string ConnectionString { get; private set; } = "";
    public static ThuocRepository Thuoc { get; private set; } = null!;
    public static SearchService Search { get; private set; } = null!;
    public static void Init()
    {
        var cfg = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false)
        .Build();
        ConnectionString = cfg.GetConnectionString("NhaThuoc")
        ?? throw new InvalidOperationException("Thiếu chuỗi kết nối NhaThuoc trong appsettings.json");
        Thuoc = new ThuocRepository(ConnectionString);
        Search = new SearchService(Thuoc);
        Users = new UserRepository(ConnectionString);
        Auth = new AuthService(Users);
        DanhMuc = new DanhMucService(new DanhMucRepository(ConnectionString), Search);
        Kho = new KhoService(new KhoRepository(ConnectionString));
    }
    public static UserRepository Users { get; private set; } = null!;
    public static AuthService Auth { get; private set; } = null!;
    public static NguoiDung? NguoiDungHienTai { get; set; }
    public static DanhMucService DanhMuc { get; private set; } = null!;
    public static KhoService Kho { get; private set; } = null!;

}
