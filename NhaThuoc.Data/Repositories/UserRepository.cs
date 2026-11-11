using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Data.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly string _cs;
    public UserRepository(string connectionString) => _cs = connectionString;

    public async Task<TaiKhoan?> LayTheoTenAsync(string tenDangNhap, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(
            @"SELECT MaND, TenDangNhap, HoTen, MaVaiTro, MatKhauHash
              FROM dbo.NguoiDung WHERE TenDangNhap = @ten AND HoatDong = 1", cn);
        cmd.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = tenDangNhap;
        await using var r = await cmd.ExecuteReaderAsync(ct);
        if (!await r.ReadAsync(ct)) return null;
        var nd = new NguoiDung(r.GetInt32(0), r.GetString(1), r.GetString(2), (VaiTro)r.GetInt32(3));
        return new TaiKhoan(nd, r.GetString(4));
    }

    public async Task<int> DemAsync(CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.NguoiDung", cn);
        return Convert.ToInt32(await cmd.ExecuteScalarAsync(ct));
    }

    public async Task TaoAsync(string tenDangNhap, string matKhauHash, string hoTen, VaiTro vaiTro, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(
            @"INSERT dbo.NguoiDung (TenDangNhap, MatKhauHash, HoTen, MaVaiTro)
              VALUES (@ten, @hash, @hoTen, @vt)", cn);
        cmd.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = tenDangNhap;
        cmd.Parameters.Add("@hash", SqlDbType.VarChar, 100).Value = matKhauHash;
        cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 100).Value = hoTen;
        cmd.Parameters.Add("@vt", SqlDbType.Int).Value = (int)vaiTro;
        await cmd.ExecuteNonQueryAsync(ct);
    }

    public async Task GhiNhatKyAsync(int? maND, string hanhDong, string? chiTiet, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(
            "INSERT dbo.NhatKy (MaND, HanhDong, ChiTiet) VALUES (@nd, @hd, @ct)", cn);
        cmd.Parameters.Add("@nd", SqlDbType.Int).Value = (object?)maND ?? DBNull.Value;
        cmd.Parameters.Add("@hd", SqlDbType.VarChar, 50).Value = hanhDong;
        cmd.Parameters.Add("@ct", SqlDbType.NVarChar, 300).Value = (object?)chiTiet ?? DBNull.Value;
        await cmd.ExecuteNonQueryAsync(ct);
    }
}