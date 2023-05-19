using System;
using System.Collections.Generic;

namespace DaiLyOTO.Models;

public partial class Xe
{
    public string MaXe { get; set; } = null!;

    public string TenXe { get; set; } = null!;

    public string MauSac { get; set; } = null!;

    public string KieuXe { get; set; } = null!;

    public string NamSx { get; set; } = null!;

    public string MoTa { get; set; } = null!;

    public int GiaBan { get; set; }

    public int? GiamGia { get; set; }

    public string FileAnh { get; set; } = null!;

    public int SoLuong { get; set; }

    public string MaDong { get; set; } = null!;

    public virtual ICollection<AnhChiTiet> AnhChiTiets { get; set; } = new List<AnhChiTiet>();

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; set; } = new List<ChiTietHdb>();

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; set; } = new List<ChiTietHdn>();

    public virtual ICollection<DangKyLaiThu> DangKyLaiThus { get; set; } = new List<DangKyLaiThu>();

    public virtual DongXe MaDongNavigation { get; set; } = null!;
}
