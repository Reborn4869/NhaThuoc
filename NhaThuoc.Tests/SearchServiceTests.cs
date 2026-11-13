using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;
using Xunit;

namespace NhaThuoc.Tests;

public class SearchServiceTests
{
    private sealed class FakeThuocRepo : IThuocRepository
    {
        public List<string> DaGoiTim { get; } = new();
        public int SoLanLayTuDien { get; private set; }
        public List<string>? HoatChatNhan { get; private set; }
        public bool? TatCaNhan { get; private set; }

        public Task<List<ThuocKetQua>> TimAsync(string tuKhoa, BoLoc loc, CancellationToken ct = default)
        {
            DaGoiTim.Add(tuKhoa);
            var ds = tuKhoa == "panadol"
                ? new List<ThuocKetQua> { new() { MaThuoc = 1, TenThuoc = "Panadol 500mg" } }
                : new List<ThuocKetQua>();
            return Task.FromResult(ds);
        }

        public Task<List<ThuocKetQua>> TimTheoHoatChatAsync(IEnumerable<string> hoatChat, bool tatCa, CancellationToken ct = default)
        {
            HoatChatNhan = hoatChat.ToList();
            TatCaNhan = tatCa;
            return Task.FromResult(new List<ThuocKetQua>());
        }

        public Task<HashSet<string>> LayTuDienAsync(CancellationToken ct = default)
        {
            SoLanLayTuDien++;
            return Task.FromResult(new HashSet<string> { "panadol", "500mg" });
        }

        public Task<List<ThuocKetQua>> ThuocCungHoatChatAsync(int maThuoc, CancellationToken ct = default)
            => Task.FromResult(new List<ThuocKetQua>());
        public Task<ThuocChiTiet?> LayChiTietAsync(int maThuoc, CancellationToken ct = default)
            => Task.FromResult<ThuocChiTiet?>(null);
        public Task<List<DanhMucItem>> LayNhomAsync(CancellationToken ct = default)
            => Task.FromResult(new List<DanhMucItem>());
        public Task<List<DanhMucItem>> LayDangBaoCheAsync(CancellationToken ct = default)
            => Task.FromResult(new List<DanhMucItem>());
    }

    [Fact]
    public async Task TuKhoaQuaNgan_KhongGoiCsdl()
    {
        var repo = new FakeThuocRepo();
        var kq = await new SearchService(repo).TimAsync("a", new BoLoc());
        Assert.Empty(kq.Thuoc);
        Assert.Empty(repo.DaGoiTim);
    }

    [Fact]
    public async Task BoDauVaCatKhoangTrangTruocKhiGoiCsdl()
    {
        var repo = new FakeThuocRepo();
        var kq = await new SearchService(repo).TimAsync("  PANADOL  ", new BoLoc());
        Assert.Equal(new[] { "panadol" }, repo.DaGoiTim);
        Assert.Single(kq.Thuoc);
        Assert.Null(kq.DaSuaThanh);
    }

    [Fact]
    public async Task KhongCoKetQua_ThuSuaChinhTa()
    {
        var repo = new FakeThuocRepo();
        var kq = await new SearchService(repo).TimAsync("Pana Dol", new BoLoc());
        Assert.Equal(new[] { "pana dol", "panadol" }, repo.DaGoiTim);
        Assert.Equal("panadol", kq.DaSuaThanh);
        Assert.Single(kq.Thuoc);
    }

    [Fact]
    public async Task KhongSuaDuoc_TraRongVaChiGoiMotLan()
    {
        var repo = new FakeThuocRepo();
        var kq = await new SearchService(repo).TimAsync("xyzabc", new BoLoc());
        Assert.Empty(kq.Thuoc);
        Assert.Null(kq.DaSuaThanh);
        Assert.Single(repo.DaGoiTim);
    }

    [Fact]
    public async Task TuDienChiNapMotLan_RoiNapLaiSauLamMoi()
    {
        var repo = new FakeThuocRepo();
        var svc = new SearchService(repo);
        await svc.TimAsync("xyzabc", new BoLoc());
        await svc.TimAsync("qwerty", new BoLoc());
        Assert.Equal(1, repo.SoLanLayTuDien);
        svc.LamMoiTuDien();
        await svc.TimAsync("qwerty", new BoLoc());
        Assert.Equal(2, repo.SoLanLayTuDien);
    }

    [Fact]
    public async Task TimNhieuHoatChat_ChuanHoaDanhSach()
    {
        var repo = new FakeThuocRepo();
        await new SearchService(repo).TimTheoHoatChatAsync("Paracetamol + Cafein , ", tatCa: true);
        Assert.Equal(new[] { "paracetamol", "cafein" }, repo.HoatChatNhan);
        Assert.True(repo.TatCaNhan);
    }
}