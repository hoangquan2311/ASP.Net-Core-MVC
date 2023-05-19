using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class ChiTietHdn
{
    public string MaCthd { get; set; } = null!;

    public int SoLuong { get; set; }

    public int GiaNhap { get; set; }

    public string SoHoaDon { get; set; } = null!;

    public string MaXe { get; set; } = null!;

    public virtual Xe MaXeNavigation { get; set; } = null!;

    public virtual HoaDonNhap SoHoaDonNavigation { get; set; } = null!;
}
