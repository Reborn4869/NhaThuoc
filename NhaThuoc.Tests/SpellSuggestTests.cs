using NhaThuoc.Core.Services;
using Xunit;

namespace NhaThuoc.Tests;

public class SpellSuggestTests
{
    private static readonly HashSet<string> TuDien = new() { "panadol", "paracetamol", "amoxicillin", "metformin", "500mg" };

    [Theory]
    [InlineData("kitten", "sitting", 3)]
    [InlineData("", "abc", 3)]
    [InlineData("abc", "abc", 0)]
    [InlineData("panadl", "panadol", 1)]
    public void Levenshtein_TinhDungKhoangCach(string a, string b, int mong)
        => Assert.Equal(mong, SpellSuggest.Levenshtein(a, b));

    [Fact] public void Sua_GopTuGoRoi() => Assert.Equal("panadol", SpellSuggest.Sua("pana dol", TuDien));
    [Fact] public void Sua_ThieuMotKyTu() => Assert.Equal("panadol", SpellSuggest.Sua("panadl", TuDien));
    [Fact] public void Sua_SaiMotKyTu() => Assert.Equal("metformin", SpellSuggest.Sua("metfomin", TuDien));
    [Fact] public void Sua_DaDungThiKhongSua() => Assert.Null(SpellSuggest.Sua("panadol", TuDien));
    [Fact] public void Sua_QuaXaThiKhongSua() => Assert.Null(SpellSuggest.Sua("xyzabc", TuDien));
    [Fact] public void Sua_TuNganChiChoSaiMotKyTu() => Assert.Null(SpellSuggest.Sua("pxy", TuDien));
}