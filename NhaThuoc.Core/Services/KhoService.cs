using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Services;

public sealed class KhoService
{
    private readonly IKhoRepository _repo;
    public KhoService(IKhoRepository repo) => _repo = repo;

    public Task<List<DanhMucItem>> LayNhaCungCapAsync() => _repo.LayNhaCungCapAsync();

    public Task<int> NhapKhoAsync(PhieuNhapDto pn)
    {
        if (pn.MaNCC <= 0) throw new NghiepVuException("Hãy chọn nhà cung cấp.");
        if (pn.Dong.Count == 0) throw new NghiepVuException("Phiếu nhập chưa có dòng nào.");
        foreach (var d in pn.Dong)
        {
            var ten = string.IsNullOrWhiteSpace(d.TenThuoc) ? $"Thuốc mã {d.MaThuoc}" : d.TenThuoc;
            if (string.IsNullOrWhiteSpace(d.SoLo)) throw new NghiepVuException($"{ten}: thiếu số lô.");
            if (d.SoLuong <= 0) throw new NghiepVuException($"{ten}: số lượng phải lớn hơn 0.");
            if (d.GiaNhap < 0) throw new NghiepVuException($"{ten}: giá nhập không được âm.");
            if (d.HanDung.Date <= DateTime.Today) throw new NghiepVuException($"{ten}: hạn dùng phải sau hôm nay.");
            if (d.NgaySX is { } nsx && nsx.Date > d.HanDung.Date)
                throw new NghiepVuException($"{ten}: ngày sản xuất không thể sau hạn dùng.");
        }
        return _repo.TaoPhieuNhapAsync(pn);
    }
}