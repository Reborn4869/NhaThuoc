using NhaThuoc.Core.Services;
using Xunit;

namespace NhaThuoc.Tests;

public class TextNormalizerTests
{
    [Theory]
    [InlineData("Đau Đầu", "dau dau")]
    [InlineData("  Hạ   SỐT ", "ha sot")]
    [InlineData("Paracetamol 500mg", "paracetamol 500mg")]
    [InlineData("Kẽm gluconat", "kem gluconat")]
    [InlineData("Sắt fumarat - Acid folic", "sat fumarat - acid folic")]
    [InlineData("", "")]
    [InlineData(null, "")]
    public void BoDau_ChuanHoaDung(string? vao, string ra)
        => Assert.Equal(ra, TextNormalizer.BoDau(vao));
}