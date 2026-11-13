using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;
using Xunit;

namespace NhaThuoc.Tests;

public class NghiepVuTests
{
    private sealed class FakeKho : IKhoRepository
    {
        public int SoLanLuu { get; private set; }
        public Task<int> TaoPhieuNhapAsync(PhieuNhapDto pn, CancellationToken ct = default) { SoLanLuu++; return Task.FromResult(7); }
        public Task<List<DanhMucItem>> LayNhaCungCapAsync(CancellationToken ct = default) => Task.FromResult(new List<DanhMucItem>());
    }

    private sealed class FakeBanHang : IBanHangRepository
    {
        public HoaDonDto? DaNhan { get; private set; }
        public Task<int> LapHoaDonAsync(HoaDonDto hd, CancellationToken ct = default) { DaNhan = hd; return Task.FromResult(1); }
        public Task HuyHoaDonAsync(int maHD, int maND, CancellationToken ct = default) => Task.CompletedTask;
        public Task<HoaDonTomTat?> LayHoaDonAsync(int maHD, CancellationToken ct = default) => Task.FromResult<HoaDonTomTat?>(null);
    }

    private static PhieuNhapDto PhieuHopLe() => new()
    {
        MaNCC = 1,
        MaND = 1,
        Dong = { new DongNhap { MaThuoc = 1, TenThuoc = "A", SoLo = "L1", HanDung = DateTime.Today.AddDays(100), SoLuong = 10, GiaNhap = 100 } }
    };

    [Fact]
    public async Task NhapKho_HopLe_DuocLuu()
    {
        var repo = new FakeKho();
        Assert.Equal(7, await new KhoService(repo).NhapKhoAsync(PhieuHopLe()));
        Assert.Equal(1, repo.SoLanLuu);
    }

    [Fact]
    public async Task NhapKho_HanDungQuaKhu_BiTuChoi()
    {
        var repo = new FakeKho();
        var pn = PhieuHopLe();
        pn.Dong[0].HanDung = DateTime.Today;
        await Assert.ThrowsAsync<NghiepVuException>(async () => await new KhoService(repo).NhapKhoAsync(pn));
        Assert.Equal(0, repo.SoLanLuu);
    }

    [Fact]
    public async Task NhapKho_SoLuongKhong_BiTuChoi()
    {
        var pn = PhieuHopLe();
        pn.Dong[0].SoLuong = 0;
        await Assert.ThrowsAsync<NghiepVuException>(async () => await new KhoService(new FakeKho()).NhapKhoAsync(pn));
    }

    [Fact]
    public async Task NhapKho_PhieuRong_BiTuChoi()
    {
        var pn = new PhieuNhapDto { MaNCC = 1, MaND = 1 };
        await Assert.ThrowsAsync<NghiepVuException>(async () => await new KhoService(new FakeKho()).NhapKhoAsync(pn));
    }

    [Fact]
    public async Task BanHang_GopDongTrungThuoc()
    {
        var repo = new FakeBanHang();
        var hd = new HoaDonDto
        {
            MaND = 1,
            Dong = { new DongBan { MaThuoc = 5, SoLuong = 2 }, new DongBan { MaThuoc = 5, SoLuong = 3 }, new DongBan { MaThuoc = 6, SoLuong = 1 } }
        };
        await new BanHangService(repo).LapHoaDonAsync(hd);
        Assert.Equal(2, repo.DaNhan!.Dong.Count);
        Assert.Equal(5, repo.DaNhan.Dong.Single(d => d.MaThuoc == 5).SoLuong);
    }

    [Fact]
    public async Task BanHang_GioTrong_BiTuChoi()
        => await Assert.ThrowsAsync<NghiepVuException>(async () =>
            await new BanHangService(new FakeBanHang()).LapHoaDonAsync(new HoaDonDto { MaND = 1 }));

    [Fact]
    public async Task BanHang_SoLuongAm_BiTuChoi()
    {
        var hd = new HoaDonDto { MaND = 1, Dong = { new DongBan { MaThuoc = 5, SoLuong = -1 } } };
        await Assert.ThrowsAsync<NghiepVuException>(async () => await new BanHangService(new FakeBanHang()).LapHoaDonAsync(hd));
    }

    [Fact]
    public async Task BanHang_GiamGiaAm_BiTuChoi()
    {
        var hd = new HoaDonDto { MaND = 1, GiamGia = -1, Dong = { new DongBan { MaThuoc = 5, SoLuong = 1 } } };
        await Assert.ThrowsAsync<NghiepVuException>(async () => await new BanHangService(new FakeBanHang()).LapHoaDonAsync(hd));
    }

    [Theory]
    [InlineData(VaiTro.QuanTri, ChucNang.NhapKho, true)]
    [InlineData(VaiTro.ThuNgan, ChucNang.NhapKho, false)]
    [InlineData(VaiTro.ThuNgan, ChucNang.BanHang, true)]
    [InlineData(VaiTro.ThuKho, ChucNang.BanHang, false)]
    [InlineData(VaiTro.DuocSi, ChucNang.QuanTri, false)]
    public void PhanQuyen_DungTheoVaiTro(VaiTro vt, ChucNang cn, bool mong)
        => Assert.Equal(mong, AuthService.DuocPhep(vt, cn));
}