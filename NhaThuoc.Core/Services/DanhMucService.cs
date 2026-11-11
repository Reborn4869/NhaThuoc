using System.Globalization;
using System.Text;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Services;

public sealed class DanhMucService
{
    private readonly IDanhMucRepository _repo;
    private readonly SearchService _search;

    public DanhMucService(IDanhMucRepository repo, SearchService search)
    {
        _repo = repo;
        _search = search;
    }

    public async Task<int> LuuAsync(ThuocEdit t)
    {
        var ma = await LuuKhongLamMoiAsync(t);
        _search.LamMoiTuDien();
        return ma;
    }

    private async Task<int> LuuKhongLamMoiAsync(ThuocEdit t)
    {
        t.TenThuoc = t.TenThuoc.Trim();
        if (t.TenThuoc.Length == 0) throw new NghiepVuException("Tên thuốc không được để trống.");
        if (t.GiaBan < 0) throw new NghiepVuException("Giá bán không được âm.");
        if (string.IsNullOrWhiteSpace(t.DonViTinh)) throw new NghiepVuException("Cần nhập đơn vị tính.");
        if (t.HoatChat.Count == 0)
            throw new NghiepVuException("Mỗi thuốc cần ít nhất một hoạt chất, nếu không sẽ không tìm được theo thành phần.");
        if (t.HoatChat.Select(h => h.MaHC).Distinct().Count() != t.HoatChat.Count)
            throw new NghiepVuException("Có hoạt chất bị chọn trùng.");
        return await _repo.LuuThuocAsync(t, TextNormalizer.BoDau(t.TenThuoc));
    }

    public async Task AnAsync(int maThuoc)
    {
        await _repo.AnThuocAsync(maThuoc);
        _search.LamMoiTuDien();
    }

    public Task<ThuocEdit?> LayAsync(int maThuoc) => _repo.LayThuocAsync(maThuoc);
    public Task<List<DanhMucItem>> LayHoatChatAsync() => _repo.LayHoatChatAsync();

    public async Task<int> ThemHoatChatAsync(string ten, IEnumerable<string> alias)
    {
        ten = ten.Trim();
        if (ten.Length == 0) throw new NghiepVuException("Tên hoạt chất không được để trống.");
        var dsAlias = alias.Where(a => !string.IsNullOrWhiteSpace(a))
                           .Select(a => (a.Trim(), TextNormalizer.BoDau(a))).ToList();
        var ma = await _repo.TaoHoatChatAsync(ten, TextNormalizer.BoDau(ten), dsAlias);
        _search.LamMoiTuDien();
        return ma;
    }

    public async Task<(int ThanhCong, List<string> Loi)> NhapCsvAsync(string duongDan)
    {
        var nhom = await _repo.LayNhomTheoTenKdAsync();
        var dang = await _repo.LayDangTheoTenKdAsync();
        var hoatChat = await _repo.LayHoatChatTheoTenKdAsync();
        var loi = new List<string>();
        int ok = 0, dong = 1;

        foreach (var line in File.ReadLines(duongDan, Encoding.UTF8).Skip(1))
        {
            dong++;
            if (string.IsNullOrWhiteSpace(line)) continue;
            try
            {
                var c = line.Split(';');
                if (c.Length < 8) throw new NghiepVuException("thiếu cột, cần đủ 8 cột");
                var t = new ThuocEdit
                {
                    TenThuoc = c[0],
                    MaVach = string.IsNullOrWhiteSpace(c[1]) ? null : c[1].Trim(),
                    GiaBan = decimal.Parse(c[2], CultureInfo.InvariantCulture),
                    DonViTinh = c[3].Trim(),
                    KeDon = c[4].Trim() == "1",
                    MaNhom = TraMa(nhom, c[5]),
                    MaDang = TraMa(dang, c[6])
                };
                foreach (var muc in c[7].Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                {
                    var phan = muc.Split(':');
                    var ten = phan[0].Trim();
                    var khoa = TextNormalizer.BoDau(ten);
                    if (!hoatChat.TryGetValue(khoa, out var ma))        // hoạt chất mới: tạo luôn
                    {
                        ma = await _repo.TaoHoatChatAsync(ten, khoa, Array.Empty<(string, string)>());
                        hoatChat[khoa] = ma;
                    }
                    t.HoatChat.Add(new HoatChatDong(ma, phan.Length > 1 ? phan[1].Trim() : null));
                }
                await LuuKhongLamMoiAsync(t);
                ok++;
            }
            catch (Exception ex)
            {
                loi.Add($"Dòng {dong}: {ex.Message}");
            }
        }
        _search.LamMoiTuDien();
        return (ok, loi);
    }

    private static int? TraMa(Dictionary<string, int> bang, string ten)
        => bang.TryGetValue(TextNormalizer.BoDau(ten), out var ma) ? ma : null;
}