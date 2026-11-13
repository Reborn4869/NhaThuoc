using System.Data;
using Microsoft.Data.SqlClient;
using NhaThuoc.Core.Models;

namespace NhaThuoc.Data.Repositories;

public sealed class BaoCaoRepository
{
    private readonly string _cs;
    public BaoCaoRepository(string connectionString) => _cs = connectionString;

    /// <param name="thamSo">Số ngày (sắp hết hạn), ngưỡng tồn (sắp hết hàng) hoặc số dòng (bán chạy).</param>
    public Task<DataTable> LayAsync(LoaiBaoCao loai, DateTime tu, DateTime den, int thamSo) => loai switch
    {
        LoaiBaoCao.DoanhThuTheoNgay => Goi("dbo.sp_DoanhThuTheoNgay",
            ("@Tu", SqlDbType.Date, tu.Date), ("@Den", SqlDbType.Date, den.Date)),
        LoaiBaoCao.ThuocBanChay => Goi("dbo.sp_ThuocBanChay",
            ("@Tu", SqlDbType.Date, tu.Date), ("@Den", SqlDbType.Date, den.Date), ("@Top", SqlDbType.Int, thamSo)),
        LoaiBaoCao.ThuocSapHetHan => Goi("dbo.sp_ThuocSapHetHan", ("@SoNgay", SqlDbType.Int, thamSo)),
        LoaiBaoCao.ThuocSapHetHang => Goi("dbo.sp_ThuocSapHetHang", ("@Nguong", SqlDbType.Int, thamSo)),
        LoaiBaoCao.TonKho => Goi("dbo.sp_TonKho"),
        _ => throw new ArgumentOutOfRangeException(nameof(loai))
    };

    private async Task<DataTable> Goi(string tenProc, params (string Ten, SqlDbType Kieu, object Gia)[] thamSo)
    {
        await using var cn = new SqlConnection(_cs);
        await cn.OpenAsync();
        await using var cmd = new SqlCommand(tenProc, cn) { CommandType = CommandType.StoredProcedure };
        foreach (var (ten, kieu, gia) in thamSo) cmd.Parameters.Add(ten, kieu).Value = gia;
        var bang = new DataTable();
        await using var r = await cmd.ExecuteReaderAsync();
        bang.Load(r);
        return bang;
    }
}