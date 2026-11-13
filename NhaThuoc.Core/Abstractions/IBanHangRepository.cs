using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Abstractions;

public interface IBanHangRepository
{
    Task<int> LapHoaDonAsync(HoaDonDto hd, CancellationToken ct = default);
    Task HuyHoaDonAsync(int maHD, int maND, CancellationToken ct = default);
    Task<HoaDonTomTat?> LayHoaDonAsync(int maHD, CancellationToken ct = default);
}