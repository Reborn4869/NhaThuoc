namespace NhaThuoc.Core.Models;

public sealed class DongBan
{
    public int MaThuoc { get; set; }
    public string TenThuoc { get; set; } = "";
    public decimal DonGia { get; set; }
    public int SoLuong { get; set; }
    public int TonKho { get; set; }          // để giao diện chặn bán quá tồn
    public bool KeDon { get; set; }
    public decimal ThanhTien => DonGia * SoLuong;
}

public sealed class HoaDonDto
{
    public int MaND { get; set; }
    public int? MaKH { get; set; }
    public decimal GiamGia { get; set; }
    public string? ThongTinDon { get; set; }
    public List<DongBan> Dong { get; set; } = new();
}

public sealed record HoaDonTomTat(decimal TongTien, DateTime NgayLap, string TrangThai);