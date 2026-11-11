using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Abstractions;

public interface IDanhMucRepository
{
    Task<int> LuuThuocAsync(ThuocEdit t, string tenKd, CancellationToken ct = default);
    Task AnThuocAsync(int maThuoc, CancellationToken ct = default);
    Task<ThuocEdit?> LayThuocAsync(int maThuoc, CancellationToken ct = default);
    Task<List<DanhMucItem>> LayHoatChatAsync(CancellationToken ct = default);
    Task<int> TaoHoatChatAsync(string ten, string tenKd, IReadOnlyList<(string Ten, string TenKd)> alias, CancellationToken ct = default);
    // Khóa của từ điển là tên đã bỏ dấu; giá trị là mã
    Task<Dictionary<string, int>> LayNhomTheoTenKdAsync(CancellationToken ct = default);
    Task<Dictionary<string, int>> LayDangTheoTenKdAsync(CancellationToken ct = default);
    Task<Dictionary<string, int>> LayHoatChatTheoTenKdAsync(CancellationToken ct = default);
}