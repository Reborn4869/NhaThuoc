using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Abstractions;

public interface IKhoRepository
{
    Task<int> TaoPhieuNhapAsync(PhieuNhapDto pn, CancellationToken ct = default);
    Task<List<DanhMucItem>> LayNhaCungCapAsync(CancellationToken ct = default);
}