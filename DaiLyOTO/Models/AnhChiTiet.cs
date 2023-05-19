using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class AnhChiTiet
{
    public string MaAct { get; set; } = null!;

    public string TenFile { get; set; } = null!;

    public string MaXe { get; set; } = null!;

    public virtual Xe MaXeNavigation { get; set; } = null!;
}
