namespace NhaThuoc.Core.Services;
public static class SpellSuggest
{
    public static int Levenshtein(string a, string b)
    {
        if (a == b) return 0;
        if (a.Length == 0) return b.Length;
        if (b.Length == 0) return a.Length;
        var prev = new int[b.Length + 1];
        var curr = new int[b.Length + 1];
        for (int j = 0; j <= b.Length; j++) prev[j] = j;
        for (int i = 1; i <= a.Length; i++)
        {
            curr[0] = i;
            for (int j = 1; j <= b.Length; j++)
            {
                int cost = a[i - 1] == b[j - 1] ? 0 : 1;
                curr[j] = Math.Min(Math.Min(curr[j - 1] + 1, prev[j] + 1),
                prev[j - 1] + cost);
            }
            (prev, curr) = (curr, prev);
        }
        return prev[b.Length];
    }
    private static string? TuGanNhat(string tu, HashSet<string> tuDien)
    {
        int nguong = tu.Length <= 4 ? 1 : 2;
        string? tot = null;
        int dTot = int.MaxValue;
        foreach (var t in tuDien)
        {
            if (Math.Abs(t.Length - tu.Length) > nguong) continue; // loại nhanh
        int d = Levenshtein(tu, t);
            if (d <= nguong && (d < dTot || (d == dTot && tot != null &&
            t.Length < tot.Length)))
            {
                tot = t;
                dTot = d;
            }
        }
        return tot;
    }
    /// <summary>Trả về cụm từ đã sửa, hoặc null nếu không cần/không sửa được.</summary>
public static string? Sua(string kd, HashSet<string> tuDien)
    {
        if (tuDien.Contains(kd)) return null;
        var gop = kd.Replace(" ", "");
        if (gop != kd)
        {
            if (tuDien.Contains(gop)) return gop;
            var g = TuGanNhat(gop, tuDien);
            if (g != null) return g;
        }
        var ketQua = new List<string>();
        bool doi = false;
        foreach (var tu in kd.Split(' ',
        StringSplitOptions.RemoveEmptyEntries))
        {
            if (tuDien.Contains(tu)) { ketQua.Add(tu); continue; }
            var s = TuGanNhat(tu, tuDien);
            if (s == null) return null;
            ketQua.Add(s);
            doi = true;
        }
        return doi ? string.Join(' ', ketQua) : null;
    }
}

