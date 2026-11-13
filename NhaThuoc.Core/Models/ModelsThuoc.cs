namespace NhaThuoc.Core.Models;
public sealed class ThuocKetQua
{
    public int MaThuoc { get; init; }
    public string TenThuoc { get; init; } = "";
    public string? HoatChat { get; init; }
    public string DonViTinh { get; init; } = "";
    public decimal GiaBan { get; init; }
    public int TonKho { get; init; }
    public DateTime? HanGanNhat { get; init; }
    public string? ViTriKe { get; init; }
    public bool KeDon { get; init; }
    public string KieuKhop { get; init; } = "";
    public int Diem { get; init; }
    public bool CungHamLuong { get; init; }
    public override string ToString() => TenThuoc;
}
public sealed class BoLoc
{
    public int? MaNhom { get; set; }
    public int? MaDang { get; set; }
    public bool? KeDon { get; set; }
    public bool? ConHang { get; set; }
    public decimal? GiaMin { get; set; }
    public decimal? GiaMax { get; set; }
    public string SapXep { get; set; } = "phuhop"; // phuhop | gia | hansd| tonkho
}
public sealed record KetQuaTimKiem(IReadOnlyList<ThuocKetQua> Thuoc, string?
DaSuaThanh);
public sealed record ThuocChiTiet(string TenThuoc, string? CongDung, string?
ChongChiDinh, string? BaoQuan);
public sealed record DanhMucItem(int Ma, string Ten)
{
    public override string ToString() => Ten; // đểComboBox hiển thị tên
}