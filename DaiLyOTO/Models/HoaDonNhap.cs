using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class HoaDonNhap
{
    public string SoHoaDon { get; set; } = null!;

    public DateTime NgayNhap { get; set; }

    public int TongTien { get; set; }

    public string MaNpp { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; set; } = new List<ChiTietHdn>();

    public virtual NhaPhanPhoi MaNppNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
