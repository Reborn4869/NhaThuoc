using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
namespace NhaThuoc.Data.Repositories;
public sealed class ThuocRepository : IThuocRepository
{
    private readonly string _cs;
    public ThuocRepository(string connectionString) => _cs =
    connectionString;
    private static void Them(SqlCommand cmd, string ten, SqlDbType kieu,
    object? giaTri)
    => cmd.Parameters.Add(ten, kieu).Value = giaTri ?? DBNull.Value;
    private static SqlCommand Proc(SqlConnection cn, string ten)
    => new(ten, cn) { CommandType = CommandType.StoredProcedure };
    public async Task<List<ThuocKetQua>> TimAsync(string tuKhoa, BoLoc loc,
    CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = Proc(cn, "dbo.sp_TimThuoc");
        Them(cmd, "@TuKhoa", SqlDbType.NVarChar, tuKhoa);
        Them(cmd, "@MaNhom", SqlDbType.Int, loc.MaNhom);
        Them(cmd, "@MaDang", SqlDbType.Int, loc.MaDang);
        Them(cmd, "@KeDon", SqlDbType.Bit, loc.KeDon);
        Them(cmd, "@ConHang", SqlDbType.Bit, loc.ConHang);
        Them(cmd, "@GiaMin", SqlDbType.Decimal, loc.GiaMin);
        Them(cmd, "@GiaMax", SqlDbType.Decimal, loc.GiaMax);
        Them(cmd, "@SapXep", SqlDbType.VarChar, loc.SapXep);
        return await DocKetQuaAsync(cmd, ct);
    }
    public async Task<List<ThuocKetQua>>
    TimTheoHoatChatAsync(IEnumerable<string> hoatChat, bool tatCa,
    CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = Proc(cn, "dbo.sp_TimTheoHoatChat");
        Them(cmd, "@DanhSach", SqlDbType.NVarChar, string.Join(",",
        hoatChat));
        Them(cmd, "@CheDo", SqlDbType.VarChar, tatCa ? "AND" : "OR");
        return await DocKetQuaAsync(cmd, ct);
    }
    public async Task<List<ThuocKetQua>> ThuocCungHoatChatAsync(int maThuoc,
    CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = Proc(cn, "dbo.sp_ThuocCungHoatChat");
        Them(cmd, "@MaThuoc", SqlDbType.Int, maThuoc);
        return await DocKetQuaAsync(cmd, ct);
    }
    private static async Task<List<ThuocKetQua>> DocKetQuaAsync(SqlCommand
    cmd, CancellationToken ct)
    {
        var ds = new List<ThuocKetQua>();
        await using var r = await cmd.ExecuteReaderAsync(ct);
        int iMa = r.GetOrdinal("MaThuoc"), iTen = r.GetOrdinal("TenThuoc"),
        iHc = r.GetOrdinal("HoatChat"),
        iDvt = r.GetOrdinal("DonViTinh"), iGia = r.GetOrdinal("GiaBan"),
        iTon = r.GetOrdinal("TonKho"),
        iHan = r.GetOrdinal("HanGanNhat"), iKe = r.GetOrdinal("ViTriKe"),
        iKeDon = r.GetOrdinal("KeDon"),
        iKieu = r.GetOrdinal("KieuKhop"), iDiem = r.GetOrdinal("Diem"),
        iHl = r.GetOrdinal("CungHamLuong");
        while (await r.ReadAsync(ct))
        {
            ds.Add(new ThuocKetQua
            {
                MaThuoc = r.GetInt32(iMa),
                TenThuoc = r.GetString(iTen),
                HoatChat = r.IsDBNull(iHc) ? null : r.GetString(iHc),
                DonViTinh = r.GetString(iDvt),
                GiaBan = r.GetDecimal(iGia),
                TonKho = r.GetInt32(iTon),
                HanGanNhat = r.IsDBNull(iHan) ? null : r.GetDateTime(iHan),
                ViTriKe = r.IsDBNull(iKe) ? null : r.GetString(iKe),
                KeDon = r.GetBoolean(iKeDon),
                KieuKhop = r.GetString(iKieu),
                Diem = r.GetInt32(iDiem),
                CungHamLuong = r.GetBoolean(iHl)
            });
        }
        return ds;
    }
    /// <summary>Mọi từ (đã bỏ dấu) trong tên thuốc, hoạt chất, alias: dùng đểsửa chính tả.</summary>
public async Task<HashSet<string>> LayTuDienAsync(CancellationToken ct =
default)
    {
        const string sql = @"SELECT TenThuoc_KD FROM dbo.Thuoc WHERE HoatDong
= 1
UNION SELECT TenHC_KD FROM dbo.HoatChat
UNION SELECT TenKhac_KD FROM dbo.HoatChatAlias";
        var tuDien = new HashSet<string>();
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(sql, cn);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct))
            foreach (var tu in r.GetString(0).Split(' ',
            StringSplitOptions.RemoveEmptyEntries))
                tuDien.Add(tu);
        return tuDien;
    }
    public async Task<ThuocChiTiet?> LayChiTietAsync(int maThuoc,
    CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(
        "SELECT TenThuoc, CongDung, ChongChiDinh, BaoQuan FROM dbo.Thuoc WHERE MaThuoc = @id", cn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = maThuoc;
        await using var r = await cmd.ExecuteReaderAsync(ct);
        if (!await r.ReadAsync(ct)) return null;
        return new ThuocChiTiet(r.GetString(0),
        r.IsDBNull(1) ? null : r.GetString(1),
        r.IsDBNull(2) ? null : r.GetString(2),
        r.IsDBNull(3) ? null : r.GetString(3));
    }
    public Task<List<DanhMucItem>> LayNhomAsync(CancellationToken ct =
    default)
    => LayDanhMucAsync("SELECT MaNhom, TenNhom FROM dbo.NhomThuoc ORDER BY TenNhom", ct);
public Task<List<DanhMucItem>> LayDangBaoCheAsync(CancellationToken ct =
default)
=> LayDanhMucAsync("SELECT MaDang, TenDang FROM dbo.DangBaoChe ORDER BY TenDang", ct);
private async Task<List<DanhMucItem>> LayDanhMucAsync(string sql,
CancellationToken ct)
    {
        var ds = new List<DanhMucItem>();
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(sql, cn);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct)) ds.Add(new DanhMucItem(r.GetInt32(0),
r.GetString(1)));
        return ds;
    }
}