using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class ChiTietHdb
{
    public string MaCthd { get; set; } = null!;

    public int SoLuong { get; set; }

    public string MaXe { get; set; } = null!;

    public string SoHoaDon { get; set; } = null!;

    public virtual Xe MaXeNavigation { get; set; } = null!;

    public virtual HoaDonBan SoHoaDonNavigation { get; set; } = null!;
}
