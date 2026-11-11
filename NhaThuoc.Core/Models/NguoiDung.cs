namespace NhaThuoc.Core.Models;

public enum VaiTro { QuanTri = 1, DuocSi = 2, ThuNgan = 3, ThuKho = 4 }   // khớp bảng VaiTro
public enum ChucNang { TimThuoc, DanhMuc, NhapKho, BanHang, BaoCao, QuanTri }

public sealed record NguoiDung(int MaND, string TenDangNhap, string HoTen, VaiTro VaiTro);
public sealed record TaiKhoan(NguoiDung NguoiDung, string MatKhauHash);