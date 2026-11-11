using NhaThuoc.Core.Models;
namespace NhaThuoc.Core.Abstractions;
public interface IThuocRepository
{
    Task<List<ThuocKetQua>> TimAsync(string tuKhoa, BoLoc loc,
    CancellationToken ct = default);
    Task<List<ThuocKetQua>> TimTheoHoatChatAsync(IEnumerable<string>
    hoatChat, bool tatCa, CancellationToken ct = default);
    Task<List<ThuocKetQua>> ThuocCungHoatChatAsync(int maThuoc,
    CancellationToken ct = default);
    Task<HashSet<string>> LayTuDienAsync(CancellationToken ct = default);
    Task<ThuocChiTiet?> LayChiTietAsync(int maThuoc, CancellationToken ct =
    default);
    Task<List<DanhMucItem>> LayNhomAsync(CancellationToken ct = default);
    Task<List<DanhMucItem>> LayDangBaoCheAsync(CancellationToken ct =
    default);
}
