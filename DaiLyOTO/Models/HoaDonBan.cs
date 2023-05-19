using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class HoaDonBan
{
    public string SoHoaDon { get; set; } = null!;

    public DateTime NgayBan { get; set; }

    public string TenKh { get; set; } = null!;

    public DateTime NgaySinhKh { get; set; }

    public string Sdtkh { get; set; } = null!;

    public string DiaChiKh { get; set; } = null!;

    public string EmailKh { get; set; } = null!;

    public int TongTien { get; set; }

    public string MaNv { get; set; } = null!;

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; set; } = new List<ChiTietHdb>();

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
