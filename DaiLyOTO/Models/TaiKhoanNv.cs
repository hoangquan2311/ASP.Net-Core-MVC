using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class TaiKhoanNv
{
    public string IdtaiKhoan { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string MaNv { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
