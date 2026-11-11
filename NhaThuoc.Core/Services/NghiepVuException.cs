namespace NhaThuoc.Core.Services;

public sealed class NghiepVuException : Exception
{
    public NghiepVuException(string thongBao) : base(thongBao) { }
}