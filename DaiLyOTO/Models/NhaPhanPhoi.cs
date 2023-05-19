using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class NhaPhanPhoi
{
    public string MaNpp { get; set; } = null!;

    public string TenNpp { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();
}
