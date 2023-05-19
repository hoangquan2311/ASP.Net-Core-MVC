using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class DongXe
{
    public string MaDong { get; set; } = null!;

    public string TenDong { get; set; } = null!;

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
