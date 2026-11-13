using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace NhaThuoc.Core.Services;
public static class TextNormalizer
{
    private static readonly Regex NhieuKhoangTrang = new(@"\s+",
    RegexOptions.Compiled);
    /// <summary>"Đau Đầu" -> "dau dau": chữ thường, bỏ dấu, gộp khoảng trắng.</summary>
    public static string BoDau(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return "";
        var d = s.Trim().ToLowerInvariant().Replace('đ', 'd').Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder(d.Length);

        foreach (var c in d)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c); // Đã bỏ chữ 'return' ở đây
            }
        }

        return NhieuKhoangTrang.Replace(sb.ToString().Normalize(NormalizationForm.FormC), " ");
    }
}
