using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaiLyOTO.Models;

public partial class DangKyLaiThu
{
    public string MaDk { get; set; } = null!;

    public DateTime NgayGui { get; set; }
    [Required(ErrorMessage = "Vui lòng chọn ngày")]
    public DateTime ThoiGianDk { get; set; }
    [Required(ErrorMessage = "Họ và tên không được để trống.")]
    public string HoTen { get; set; } = null!;
    [Required(ErrorMessage = "Số điện thoại không được để trống.")]
    public string Sdt { get; set; } = null!;

    public string? GhiChu { get; set; }
    public string MaXe { get; set; } = null!;

    public virtual Xe MaXeNavigation { get; set; } = null!;
}
