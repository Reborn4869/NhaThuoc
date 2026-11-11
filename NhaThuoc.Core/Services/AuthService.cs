using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Core.Services;

public sealed class AuthService
{
    private readonly IUserRepository _repo;
    public AuthService(IUserRepository repo) => _repo = repo;

    /// <summary>Lần chạy đầu (bảng NguoiDung trống): tạo admin và 3 tài khoản mẫu. Chỉ dùng khi học tập.</summary>
    public async Task KhoiTaoAdminAsync()
    {
        if (await _repo.DemAsync() > 0) return;
        await TaoNguoiDungAsync("admin", "Admin@123", "Quản trị viên", VaiTro.QuanTri);
        await TaoNguoiDungAsync("duocsi", "Test@1234", "Dược sĩ mẫu", VaiTro.DuocSi);
        await TaoNguoiDungAsync("thungan", "Test@1234", "Thu ngân mẫu", VaiTro.ThuNgan);
        await TaoNguoiDungAsync("thukho", "Test@1234", "Thủ kho mẫu", VaiTro.ThuKho);
    }

    public Task TaoNguoiDungAsync(string ten, string matKhau, string hoTen, VaiTro vaiTro)
    {
        if (string.IsNullOrWhiteSpace(ten)) throw new NghiepVuException("Tên đăng nhập không được để trống.");
        if (matKhau.Length < 8) throw new NghiepVuException("Mật khẩu cần ít nhất 8 ký tự.");
        return _repo.TaoAsync(ten.Trim(), BCrypt.Net.BCrypt.HashPassword(matKhau), hoTen.Trim(), vaiTro);
    }

    public async Task<NguoiDung?> DangNhapAsync(string ten, string matKhau)
    {
        var tk = await _repo.LayTheoTenAsync(ten.Trim());
        if (tk is null || !BCrypt.Net.BCrypt.Verify(matKhau, tk.MatKhauHash)) return null;
        await _repo.GhiNhatKyAsync(tk.NguoiDung.MaND, "DangNhap", null);
        return tk.NguoiDung;
    }

    public static bool DuocPhep(VaiTro vt, ChucNang cn) => vt switch
    {
        VaiTro.QuanTri => true,
        VaiTro.DuocSi => cn is ChucNang.TimThuoc or ChucNang.DanhMuc or ChucNang.BanHang or ChucNang.BaoCao,
        VaiTro.ThuNgan => cn is ChucNang.TimThuoc or ChucNang.BanHang,
        VaiTro.ThuKho => cn is ChucNang.TimThuoc or ChucNang.NhapKho or ChucNang.BaoCao,
        _ => false
    };
}