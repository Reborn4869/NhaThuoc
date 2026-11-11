using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Abstractions;

public interface IUserRepository
{
    Task<TaiKhoan?> LayTheoTenAsync(string tenDangNhap, CancellationToken ct = default);
    Task<int> DemAsync(CancellationToken ct = default);
    Task TaoAsync(string tenDangNhap, string matKhauHash, string hoTen, VaiTro vaiTro, CancellationToken ct = default);
    Task GhiNhatKyAsync(int? maND, string hanhDong, string? chiTiet, CancellationToken ct = default);
}