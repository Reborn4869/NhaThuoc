using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.Data.Repositories;

public sealed class DanhMucRepository : IDanhMucRepository
{
    private readonly string _cs;
    public DanhMucRepository(string connectionString) => _cs = connectionString;

    private static void P(SqlCommand cmd, string ten, SqlDbType kieu, object? giaTri)
        => cmd.Parameters.Add(ten, kieu).Value = giaTri ?? DBNull.Value;

    public async Task<int> LuuThuocAsync(ThuocEdit t, string tenKd, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var tx = (SqlTransaction)await cn.BeginTransactionAsync(ct);
        try
        {
            string sql = t.MaThuoc == 0
                ? @"INSERT dbo.Thuoc (TenThuoc, TenThuoc_KD, MaVach, MaNhom, MaDang, MaNSX, KeDon, GiaBan,
                                     DonViTinh, ViTriKe, CongDung, ChongChiDinh, BaoQuan)
                    OUTPUT INSERTED.MaThuoc
                    VALUES (@ten, @kd, @vach, @nhom, @dang, @nsx, @kedon, @gia, @dvt, @ke, @cd, @ccd, @bq)"
                : @"UPDATE dbo.Thuoc SET TenThuoc = @ten, TenThuoc_KD = @kd, MaVach = @vach, MaNhom = @nhom,
                           MaDang = @dang, MaNSX = @nsx, KeDon = @kedon, GiaBan = @gia, DonViTinh = @dvt,
                           ViTriKe = @ke, CongDung = @cd, ChongChiDinh = @ccd, BaoQuan = @bq
                    WHERE MaThuoc = @id; SELECT @id;";
            int ma;
            await using (var cmd = new SqlCommand(sql, cn, tx))
            {
                P(cmd, "@id", SqlDbType.Int, t.MaThuoc);
                P(cmd, "@ten", SqlDbType.NVarChar, t.TenThuoc);
                P(cmd, "@kd", SqlDbType.VarChar, tenKd);
                P(cmd, "@vach", SqlDbType.VarChar, t.MaVach);
                P(cmd, "@nhom", SqlDbType.Int, t.MaNhom);
                P(cmd, "@dang", SqlDbType.Int, t.MaDang);
                P(cmd, "@nsx", SqlDbType.Int, t.MaNSX);
                P(cmd, "@kedon", SqlDbType.Bit, t.KeDon);
                P(cmd, "@gia", SqlDbType.Decimal, t.GiaBan);
                P(cmd, "@dvt", SqlDbType.NVarChar, t.DonViTinh);
                P(cmd, "@ke", SqlDbType.NVarChar, t.ViTriKe);
                P(cmd, "@cd", SqlDbType.NVarChar, t.CongDung);
                P(cmd, "@ccd", SqlDbType.NVarChar, t.ChongChiDinh);
                P(cmd, "@bq", SqlDbType.NVarChar, t.BaoQuan);
                ma = Convert.ToInt32(await cmd.ExecuteScalarAsync(ct));
            }

            await using (var xoa = new SqlCommand("DELETE dbo.Thuoc_HoatChat WHERE MaThuoc = @id", cn, tx))
            {
                P(xoa, "@id", SqlDbType.Int, ma);
                await xoa.ExecuteNonQueryAsync(ct);
            }
            foreach (var h in t.HoatChat)
            {
                await using var them = new SqlCommand(
                    "INSERT dbo.Thuoc_HoatChat (MaThuoc, MaHC, HamLuong) VALUES (@t, @hc, @hl)", cn, tx);
                P(them, "@t", SqlDbType.Int, ma);
                P(them, "@hc", SqlDbType.Int, h.MaHC);
                P(them, "@hl", SqlDbType.NVarChar, h.HamLuong);
                await them.ExecuteNonQueryAsync(ct);
            }
            await tx.CommitAsync(ct);
            return ma;
        }
        catch (SqlException ex) when (ex.Number is 2601 or 2627)
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw new NghiepVuException("Mã vạch này đã được dùng cho một thuốc khác.");
        }
        catch
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    public async Task AnThuocAsync(int maThuoc, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand("UPDATE dbo.Thuoc SET HoatDong = 0 WHERE MaThuoc = @id", cn);
        P(cmd, "@id", SqlDbType.Int, maThuoc);
        await cmd.ExecuteNonQueryAsync(ct);
    }

    public async Task<ThuocEdit?> LayThuocAsync(int maThuoc, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        ThuocEdit? t;
        await using (var cmd = new SqlCommand(
            @"SELECT MaThuoc, TenThuoc, MaVach, MaNhom, MaDang, MaNSX, KeDon, GiaBan, DonViTinh,
                     ViTriKe, CongDung, ChongChiDinh, BaoQuan
              FROM dbo.Thuoc WHERE MaThuoc = @id", cn))
        {
            P(cmd, "@id", SqlDbType.Int, maThuoc);
            await using var r = await cmd.ExecuteReaderAsync(ct);
            if (!await r.ReadAsync(ct)) return null;
            string? S(int i) => r.IsDBNull(i) ? null : r.GetString(i);
            int? I(int i) => r.IsDBNull(i) ? null : r.GetInt32(i);
            t = new ThuocEdit
            {
                MaThuoc = r.GetInt32(0),
                TenThuoc = r.GetString(1),
                MaVach = S(2),
                MaNhom = I(3),
                MaDang = I(4),
                MaNSX = I(5),
                KeDon = r.GetBoolean(6),
                GiaBan = r.GetDecimal(7),
                DonViTinh = r.GetString(8),
                ViTriKe = S(9),
                CongDung = S(10),
                ChongChiDinh = S(11),
                BaoQuan = S(12)
            };
        }
        await using (var cmd = new SqlCommand(
            "SELECT MaHC, HamLuong FROM dbo.Thuoc_HoatChat WHERE MaThuoc = @id", cn))
        {
            P(cmd, "@id", SqlDbType.Int, maThuoc);
            await using var r = await cmd.ExecuteReaderAsync(ct);
            while (await r.ReadAsync(ct))
                t.HoatChat.Add(new HoatChatDong(r.GetInt32(0), r.IsDBNull(1) ? null : r.GetString(1)));
        }
        return t;
    }

    public async Task<List<DanhMucItem>> LayHoatChatAsync(CancellationToken ct = default)
    {
        var ds = new List<DanhMucItem>();
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand("SELECT MaHC, TenHC FROM dbo.HoatChat ORDER BY TenHC", cn);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct)) ds.Add(new DanhMucItem(r.GetInt32(0), r.GetString(1)));
        return ds;
    }

    public async Task<int> TaoHoatChatAsync(string ten, string tenKd,
        IReadOnlyList<(string Ten, string TenKd)> alias, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var tx = (SqlTransaction)await cn.BeginTransactionAsync(ct);
        try
        {
            int ma;
            await using (var cmd = new SqlCommand(
                "INSERT dbo.HoatChat (TenHC, TenHC_KD) OUTPUT INSERTED.MaHC VALUES (@ten, @kd)", cn, tx))
            {
                P(cmd, "@ten", SqlDbType.NVarChar, ten);
                P(cmd, "@kd", SqlDbType.VarChar, tenKd);
                ma = Convert.ToInt32(await cmd.ExecuteScalarAsync(ct));
            }
            foreach (var a in alias)
            {
                await using var cmd = new SqlCommand(
                    "INSERT dbo.HoatChatAlias (MaHC, TenKhac, TenKhac_KD) VALUES (@hc, @ten, @kd)", cn, tx);
                P(cmd, "@hc", SqlDbType.Int, ma);
                P(cmd, "@ten", SqlDbType.NVarChar, a.Ten);
                P(cmd, "@kd", SqlDbType.VarChar, a.TenKd);
                await cmd.ExecuteNonQueryAsync(ct);
            }
            await tx.CommitAsync(ct);
            return ma;
        }
        catch (SqlException ex) when (ex.Number is 2601 or 2627)
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw new NghiepVuException("Hoạt chất này đã có trong danh mục.");
        }
        catch
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    public Task<Dictionary<string, int>> LayNhomTheoTenKdAsync(CancellationToken ct = default)
        => LayBanDoAsync("SELECT MaNhom, TenNhom FROM dbo.NhomThuoc", ct);
    public Task<Dictionary<string, int>> LayDangTheoTenKdAsync(CancellationToken ct = default)
        => LayBanDoAsync("SELECT MaDang, TenDang FROM dbo.DangBaoChe", ct);
    public Task<Dictionary<string, int>> LayHoatChatTheoTenKdAsync(CancellationToken ct = default)
        => LayBanDoAsync("SELECT MaHC, TenHC FROM dbo.HoatChat", ct);

    private async Task<Dictionary<string, int>> LayBanDoAsync(string sql, CancellationToken ct)
    {
        var bang = new Dictionary<string, int>();
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(sql, cn);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct)) bang[TextNormalizer.BoDau(r.GetString(1))] = r.GetInt32(0);
        return bang;
    }
}