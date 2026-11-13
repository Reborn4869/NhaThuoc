using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.Data.Repositories;

public sealed class KhoRepository : IKhoRepository
{
    private readonly string _cs;
    public KhoRepository(string connectionString) => _cs = connectionString;

    private static void P(SqlCommand cmd, string ten, SqlDbType kieu, object? giaTri)
        => cmd.Parameters.Add(ten, kieu).Value = giaTri ?? DBNull.Value;

    public async Task<int> TaoPhieuNhapAsync(PhieuNhapDto pn, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var tx = (SqlTransaction)await cn.BeginTransactionAsync(ct);
        try
        {
            int maPN;
            await using (var cmd = new SqlCommand(
                "INSERT dbo.PhieuNhap (MaNCC, MaND, GhiChu) OUTPUT INSERTED.MaPN VALUES (@ncc, @nd, @gc)", cn, tx))
            {
                P(cmd, "@ncc", SqlDbType.Int, pn.MaNCC);
                P(cmd, "@nd", SqlDbType.Int, pn.MaND);
                P(cmd, "@gc", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(pn.GhiChu) ? null : pn.GhiChu.Trim());
                maPN = Convert.ToInt32(await cmd.ExecuteScalarAsync(ct));
            }

            foreach (var d in pn.Dong)
            {
                // cộng dồn nếu lô đã có (cùng thuốc, số lô, hạn dùng); nếu không thì tạo lô mới
                await using var cmd = new SqlCommand(@"
                    UPDATE dbo.LoHang SET SoLuong = SoLuong + @sl
                    WHERE MaThuoc = @t AND SoLo = @lo AND HanDung = @han;
                    IF @@ROWCOUNT = 0
                        INSERT dbo.LoHang (MaThuoc, SoLo, NgaySX, HanDung, SoLuong, GiaNhap, MaPN)
                        VALUES (@t, @lo, @nsx, @han, @sl, @gia, @pn);", cn, tx);
                P(cmd, "@t", SqlDbType.Int, d.MaThuoc);
                P(cmd, "@lo", SqlDbType.VarChar, d.SoLo.Trim());
                P(cmd, "@nsx", SqlDbType.Date, d.NgaySX?.Date);
                P(cmd, "@han", SqlDbType.Date, d.HanDung.Date);
                P(cmd, "@sl", SqlDbType.Int, d.SoLuong);
                P(cmd, "@gia", SqlDbType.Decimal, d.GiaNhap);
                P(cmd, "@pn", SqlDbType.Int, maPN);
                await cmd.ExecuteNonQueryAsync(ct);
            }

            await using (var nk = new SqlCommand(
                "INSERT dbo.NhatKy (MaND, HanhDong, ChiTiet) VALUES (@nd, 'NhapKho', @ct)", cn, tx))
            {
                P(nk, "@nd", SqlDbType.Int, pn.MaND);
                P(nk, "@ct", SqlDbType.NVarChar, $"Phiếu nhập {maPN}, {pn.Dong.Count} dòng");
                await nk.ExecuteNonQueryAsync(ct);
            }

            await tx.CommitAsync(ct);
            return maPN;
        }
        catch (SqlException ex) when (ex.Number is 2601 or 2627)
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw new NghiepVuException("Có số lô đã tồn tại với hạn dùng khác. Kiểm tra lại số lô và hạn dùng.");
        }
        catch
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    public async Task<List<DanhMucItem>> LayNhaCungCapAsync(CancellationToken ct = default)
    {
        var ds = new List<DanhMucItem>();
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand("SELECT MaNCC, TenNCC FROM dbo.NhaCungCap ORDER BY TenNCC", cn);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct)) ds.Add(new DanhMucItem(r.GetInt32(0), r.GetString(1)));
        return ds;
    }
}