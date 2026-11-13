using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Services;

public sealed class BanHangService
{
    private readonly IBanHangRepository _repo;
    public BanHangService(IBanHangRepository repo) => _repo = repo;

    public Task<int> LapHoaDonAsync(HoaDonDto hd)
    {
        if (hd.Dong.Count == 0) throw new NghiepVuException("Giỏ hàng đang trống.");
        if (hd.GiamGia < 0) throw new NghiepVuException("Giảm giá không được âm.");

        // gộp các dòng trùng thuốc thành một
        hd.Dong = hd.Dong.GroupBy(d => d.MaThuoc)
            .Select(g => new DongBan { MaThuoc = g.Key, TenThuoc = g.First().TenThuoc, SoLuong = g.Sum(x => x.SoLuong) })
            .ToList();
        if (hd.Dong.Any(d => d.SoLuong <= 0)) throw new NghiepVuException("Số lượng mỗi dòng phải lớn hơn 0.");

        return _repo.LapHoaDonAsync(hd);
    }

    public Task HuyHoaDonAsync(int maHD, int maND) => _repo.HuyHoaDonAsync(maHD, maND);
    public Task<HoaDonTomTat?> LayHoaDonAsync(int maHD) => _repo.LayHoaDonAsync(maHD);
}