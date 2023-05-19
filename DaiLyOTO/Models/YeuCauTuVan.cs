using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DaiLyOTO.Models;

public partial class YeuCauTuVan
{
    public string MaYc { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    [Required(ErrorMessage = "Họ và tên không được để trống.")]
    public string HoTen { get; set; } = null!;

    [Required(ErrorMessage = "Số điện thoại không được để trống.")]
    public string Sdt { get; set; } = null!;

    public string? NoiDung { get; set; }

    public DateTime NgayGui { get; set; }

    public string MaNv { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
