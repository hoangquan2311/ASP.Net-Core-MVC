using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateTime NgayLamViec { get; set; }

    public int LuongCoBan { get; set; }

    public DateTime NgaySinh { get; set; }

    public string MaCv { get; set; } = null!;

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();

    public virtual ViTriCongViec MaCvNavigation { get; set; } = null!;

    public virtual ICollection<TaiKhoanNv> TaiKhoanNvs { get; set; } = new List<TaiKhoanNv>();

    public virtual ICollection<YeuCauTuVan> YeuCauTuVans { get; set; } = new List<YeuCauTuVan>();
}
