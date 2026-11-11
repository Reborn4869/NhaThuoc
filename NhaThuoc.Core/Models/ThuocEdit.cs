namespace NhaThuoc.Core.Models;

public sealed record HoatChatDong(int MaHC, string? HamLuong);

public sealed class ThuocEdit
{
    public int MaThuoc { get; set; }              // 0 = thêm mới
    public string TenThuoc { get; set; } = "";
    public string? MaVach { get; set; }
    public int? MaNhom { get; set; }
    public int? MaDang { get; set; }
    public int? MaNSX { get; set; }
    public bool KeDon { get; set; }
    public decimal GiaBan { get; set; }
    public string DonViTinh { get; set; } = "Viên";
    public string? ViTriKe { get; set; }
    public string? CongDung { get; set; }
    public string? ChongChiDinh { get; set; }
    public string? BaoQuan { get; set; }
    public List<HoatChatDong> HoatChat { get; set; } = new();
}