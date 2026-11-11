using System.Text.RegularExpressions;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
namespace NhaThuoc.Core.Services;
public sealed class SearchService
{
    private readonly IThuocRepository _repo;
    private HashSet<string>? _tuDien; // nạp một lần, dùng lại cho mọi lần tìm
public SearchService(IThuocRepository repo) => _repo = repo;
    /// <summary>Tìm gộp theo tên và hoạt chất; nếu không ra gì thì thửsửa chính tả.</summary>
public async Task<KetQuaTimKiem> TimAsync(string tuKhoa, BoLoc loc,
CancellationToken ct = default)
    {
        var kd = TextNormalizer.BoDau(tuKhoa);
        if (kd.Length < 2) return new KetQuaTimKiem(Array.Empty<ThuocKetQua>
        (), null);
        var ds = await _repo.TimAsync(kd, loc, ct);
        if (ds.Count > 0) return new KetQuaTimKiem(ds, null);
        _tuDien ??= await _repo.LayTuDienAsync(ct);
        var sua = SpellSuggest.Sua(kd, _tuDien);
        if (sua == null) return new KetQuaTimKiem(ds, null);
        ds = await _repo.TimAsync(sua, loc, ct);
        return new KetQuaTimKiem(ds, ds.Count > 0 ? sua : null);
    }
    /// <summary>"paracetamol + cafein" hoặc "paracetamol, cafein"; tatCa = true là AND, false là OR.</summary>
        public async Task<List<ThuocKetQua>> TimTheoHoatChatAsync(string
    danhSach, bool tatCa, CancellationToken ct = default)
{
var cacTu = danhSach.Replace('+', ',')
.Split(',', StringSplitOptions.RemoveEmptyEntries |
StringSplitOptions.TrimEntries)
.Select(TextNormalizer.BoDau)
.Where(s => s.Length > 0)
.Distinct()
.ToList();
if (cacTu.Count == 0) return new List<ThuocKetQua>();
return await _repo.TimTheoHoatChatAsync(cacTu, tatCa, ct);
}
public Task<List<ThuocKetQua>> ThuocThayTheAsync(int maThuoc,
CancellationToken ct = default)
=> _repo.ThuocCungHoatChatAsync(maThuoc, ct);
/// <summary>Gọi sau khi thêm/sửa thuốc đểtừ điển chính tả được nạp lại.</summary>
public void LamMoiTuDien() => _tuDien = null;
}
