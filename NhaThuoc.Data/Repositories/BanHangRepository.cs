using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Abstractions;
using NhaThuoc.Core.Models;
using NhaThuoc.Core.Services;

namespace NhaThuoc.Data.Repositories;

public sealed class BanHangRepository : IBanHangRepository
{
    private readonly string _cs;
    public BanHangRepository(string connectionString) => _cs = connectionString;

    private static void P(SqlCommand cmd, string ten, SqlDbType kieu, object? giaTri)
        => cmd.Parameters.Add(ten, kieu).Value = giaTri ?? DBNull.Value;

    public async Task<int> LapHoaDonAsync(HoaDonDto hd, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var tx = (SqlTransaction)await cn.BeginTransactionAsync(ct);
        try
        {
            // 1. Giá bán hiện tại và cờ kê đơn của từng thuốc
            var info = new Dictionary<int, (string Ten, decimal Gia, bool KeDon)>();
            foreach (var d in hd.Dong)
            {
                await using var cmd = new SqlCommand(
                    "SELECT TenThuoc, GiaBan, KeDon FROM dbo.Thuoc WHERE MaThuoc = @id AND HoatDong = 1", cn, tx);
                P(cmd, "@id", SqlDbType.Int, d.MaThuoc);
                await using var r = await cmd.ExecuteReaderAsync(ct);
                if (!await r.ReadAsync(ct))
                    throw new NghiepVuException("Có thuốc không còn trong danh mục hoặc đã bị ẩn.");
                info[d.MaThuoc] = (r.GetString(0), r.GetDecimal(1), r.GetBoolean(2));
            }

            // 2. Quy tắc nghiệp vụ
            if (info.Values.Any(x => x.KeDon) && string.IsNullOrWhiteSpace(hd.ThongTinDon))
                throw new NghiepVuException("Hóa đơn có thuốc kê đơn: bắt buộc nhập thông tin đơn thuốc (bác sĩ, số đơn).");
            decimal tong = hd.Dong.Sum(x => x.SoLuong * info[x.MaThuoc].Gia) - hd.GiamGia;
            if (tong < 0) throw new NghiepVuException("Giảm giá lớn hơn tổng tiền hàng.");

            // 3. Hóa đơn
            int maHD;
            await using (var cmd = new SqlCommand(
                @"INSERT dbo.HoaDon (MaND, MaKH, GiamGia, TongTien, ThongTinDon)
                  OUTPUT INSERTED.MaHD VALUES (@nd, @kh, @gg, @tong, @don)", cn, tx))
            {
                P(cmd, "@nd", SqlDbType.Int, hd.MaND);
                P(cmd, "@kh", SqlDbType.Int, hd.MaKH);
                P(cmd, "@gg", SqlDbType.Decimal, hd.GiamGia);
                P(cmd, "@tong", SqlDbType.Decimal, tong);
                P(cmd, "@don", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(hd.ThongTinDon) ? null : hd.ThongTinDon.Trim());
                maHD = Convert.ToInt32(await cmd.ExecuteScalarAsync(ct));
            }

            // 4. FEFO: lấy lô hết hạn sớm nhất trước
            foreach (var d in hd.Dong)
            {
                var cacLo = new List<(int MaLo, int Ton)>();
                await using (var cmd = new SqlCommand(
                    @"SELECT MaLo, SoLuong FROM dbo.LoHang WITH (UPDLOCK, ROWLOCK)
                      WHERE MaThuoc = @t AND SoLuong > 0 AND HanDung >= CAST(GETDATE() AS DATE)
                      ORDER BY HanDung, MaLo", cn, tx))
                {
                    P(cmd, "@t", SqlDbType.Int, d.MaThuoc);
                    await using var r = await cmd.ExecuteReaderAsync(ct);
                    while (await r.ReadAsync(ct)) cacLo.Add((r.GetInt32(0), r.GetInt32(1)));
                }

                int canLay = d.SoLuong;
                foreach (var (maLo, ton) in cacLo)
                {
                    if (canLay == 0) break;
                    int lay = Math.Min(canLay, ton);

                    await using (var up = new SqlCommand(
                        "UPDATE dbo.LoHang SET SoLuong = SoLuong - @n WHERE MaLo = @lo AND SoLuong >= @n", cn, tx))
                    {
                        P(up, "@n", SqlDbType.Int, lay);
                        P(up, "@lo", SqlDbType.Int, maLo);
                        if (await up.ExecuteNonQueryAsync(ct) != 1)
                            throw new NghiepVuException("Tồn kho vừa thay đổi, hãy thử lại.");
                    }
                    await using (var ins = new SqlCommand(
                        @"INSERT dbo.ChiTietHoaDon (MaHD, MaLo, MaThuoc, SoLuong, DonGia)
                          VALUES (@hd, @lo, @t, @n, @gia)", cn, tx))
                    {
                        P(ins, "@hd", SqlDbType.Int, maHD);
                        P(ins, "@lo", SqlDbType.Int, maLo);
                        P(ins, "@t", SqlDbType.Int, d.MaThuoc);
                        P(ins, "@n", SqlDbType.Int, lay);
                        P(ins, "@gia", SqlDbType.Decimal, info[d.MaThuoc].Gia);
                        await ins.ExecuteNonQueryAsync(ct);
                    }
                    canLay -= lay;
                }
                if (canLay > 0)
                    throw new NghiepVuException($"Không đủ tồn kho cho \"{info[d.MaThuoc].Ten}\" (còn thiếu {canLay}).");
            }

            await using (var nk = new SqlCommand(
                "INSERT dbo.NhatKy (MaND, HanhDong, ChiTiet) VALUES (@nd, 'BanHang', @ct)", cn, tx))
            {
                P(nk, "@nd", SqlDbType.Int, hd.MaND);
                P(nk, "@ct", SqlDbType.NVarChar, $"Hóa đơn {maHD}, tổng {tong:N0}");
                await nk.ExecuteNonQueryAsync(ct);
            }

            await tx.CommitAsync(ct);
            return maHD;
        }
        catch
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    public async Task HuyHoaDonAsync(int maHD, int maND, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var tx = (SqlTransaction)await cn.BeginTransactionAsync(ct);
        try
        {
            string? trangThai;
            await using (var cmd = new SqlCommand(
                "SELECT TrangThai FROM dbo.HoaDon WITH (UPDLOCK) WHERE MaHD = @id", cn, tx))
            {
                P(cmd, "@id", SqlDbType.Int, maHD);
                trangThai = await cmd.ExecuteScalarAsync(ct) as string;
            }
            if (trangThai is null) throw new NghiepVuException("Không có hóa đơn này.");
            if (trangThai == "Huy") throw new NghiepVuException("Hóa đơn này đã được hủy trước đó.");

            await using (var cmd = new SqlCommand(@"
                UPDATE dbo.HoaDon SET TrangThai = 'Huy' WHERE MaHD = @id;
                UPDATE lo SET lo.SoLuong = lo.SoLuong + c.SL
                FROM dbo.LoHang lo
                JOIN (SELECT MaLo, SUM(SoLuong) AS SL FROM dbo.ChiTietHoaDon WHERE MaHD = @id GROUP BY MaLo) c
                  ON c.MaLo = lo.MaLo;
                INSERT dbo.NhatKy (MaND, HanhDong, ChiTiet) VALUES (@nd, 'HuyHoaDon', 'Hủy hóa đơn ' + CAST(@id AS VARCHAR(10)));", cn, tx))
            {
                P(cmd, "@id", SqlDbType.Int, maHD);
                P(cmd, "@nd", SqlDbType.Int, maND);
                await cmd.ExecuteNonQueryAsync(ct);
            }
            await tx.CommitAsync(ct);
        }
        catch
        {
            await tx.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    public async Task<HoaDonTomTat?> LayHoaDonAsync(int maHD, CancellationToken ct = default)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync(ct);
        await using var cmd = new SqlCommand(
            "SELECT TongTien, NgayLap, TrangThai FROM dbo.HoaDon WHERE MaHD = @id", cn);
        P(cmd, "@id", SqlDbType.Int, maHD);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        return await r.ReadAsync(ct) ? new HoaDonTomTat(r.GetDecimal(0), r.GetDateTime(1), r.GetString(2)) : null;
    }
}