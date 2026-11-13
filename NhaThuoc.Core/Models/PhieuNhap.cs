namespace NhaThuoc.Core.Models;

public sealed class DongNhap
{
    public int MaThuoc { get; set; }
    public string TenThuoc { get; set; } = "";     // chỉ để hiển thị trên lưới
    public string SoLo { get; set; } = "";
    public DateTime? NgaySX { get; set; }
    public DateTime HanDung { get; set; }
    public int SoLuong { get; set; }
    public decimal GiaNhap { get; set; }
}

public sealed class PhieuNhapDto
{
    public int MaNCC { get; set; }
    public int MaND { get; set; }
    public string? GhiChu { get; set; }
    public List<DongNhap> Dong { get; set; } = new();
}