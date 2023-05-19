using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaiLyOTO.Models;

public partial class QlotoContext : DbContext
{
    public QlotoContext()
    {
    }

    public QlotoContext(DbContextOptions<QlotoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnhChiTiet> AnhChiTiets { get; set; }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChiTietHdn> ChiTietHdns { get; set; }

    public virtual DbSet<DangKyLaiThu> DangKyLaiThus { get; set; }

    public virtual DbSet<DongXe> DongXes { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TaiKhoanNv> TaiKhoanNvs { get; set; }

    public virtual DbSet<ViTriCongViec> ViTriCongViecs { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    public virtual DbSet<YeuCauTuVan> YeuCauTuVans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLOTO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnhChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaAct).HasName("PK__AnhChiTi__356F66E2413780BB");

            entity.ToTable("AnhChiTiet");

            entity.Property(e => e.MaAct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaACT");
            entity.Property(e => e.MaXe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenFile)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.AnhChiTiets)
                .HasForeignKey(d => d.MaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AnhChiTiet__MaXe__59063A47");
        });

        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__ChiTietH__1E4FA771EA9F52D5");

            entity.ToTable("ChiTietHDB");

            entity.Property(e => e.MaCthd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaCTHD");
            entity.Property(e => e.MaXe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHDB__MaXe__5535A963");

            entity.HasOne(d => d.SoHoaDonNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.SoHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__SoHoa__5629CD9C");
        });

        modelBuilder.Entity<ChiTietHdn>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__ChiTietH__1E4FA7712BBDDDE1");

            entity.ToTable("ChiTietHDN");

            entity.Property(e => e.MaCthd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaCTHD");
            entity.Property(e => e.MaXe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.MaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHDN__MaXe__60A75C0F");

            entity.HasOne(d => d.SoHoaDonNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.SoHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__SoHoa__5FB337D6");
        });

        modelBuilder.Entity<DangKyLaiThu>(entity =>
        {
            entity.HasKey(e => e.MaDk).HasName("PK__DangKyLa__2725866CEA8C1C3E");

            entity.ToTable("DangKyLaiThu");

            entity.Property(e => e.MaDk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaDK");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaXe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayGui).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.ThoiGianDk)
                .HasColumnType("date")
                .HasColumnName("ThoiGianDK");

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.DangKyLaiThus)
                .HasForeignKey(d => d.MaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DangKyLaiT__MaXe__6FE99F9F");
        });

        modelBuilder.Entity<DongXe>(entity =>
        {
            entity.HasKey(e => e.MaDong).HasName("PK__DongXe__2DC587893CD4BEC8");

            entity.ToTable("DongXe");

            entity.Property(e => e.MaDong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenDong).HasMaxLength(50);
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon).HasName("PK__HoaDonBa__012E9E5260372D31");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.SoHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiaChiKh)
                .HasMaxLength(100)
                .HasColumnName("DiaChiKH");
            entity.Property(e => e.EmailKh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBan).HasColumnType("date");
            entity.Property(e => e.NgaySinhKh)
                .HasColumnType("date")
                .HasColumnName("NgaySinhKH");
            entity.Property(e => e.Sdtkh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDTKH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__MaNV__4BAC3F29");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon).HasName("PK__HoaDonNh__012E9E5294CD91EB");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.SoHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaNpp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNPP");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayNhap).HasColumnType("date");

            entity.HasOne(d => d.MaNppNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNpp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonNha__MaNPP__5BE2A6F2");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonNhap__MaNV__5CD6CB2B");
        });

        modelBuilder.Entity<NhaPhanPhoi>(entity =>
        {
            entity.HasKey(e => e.MaNpp).HasName("PK__NhaPhanP__3A18330C61D7AD57");

            entity.ToTable("NhaPhanPhoi");

            entity.Property(e => e.MaNpp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNPP");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNpp)
                .HasMaxLength(50)
                .HasColumnName("TenNPP");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A8B63F930");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaCv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.NgayLamViec).HasColumnType("date");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__MaCV__45F365D3");
        });

        modelBuilder.Entity<TaiKhoanNv>(entity =>
        {
            entity.HasKey(e => e.IdtaiKhoan).HasName("PK__TaiKhoan__BC5F907CE6005272");

            entity.ToTable("TaiKhoanNV");

            entity.Property(e => e.IdtaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDTaiKhoan");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayTao).HasColumnType("date");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.TaiKhoanNvs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoanNV__MaNV__48CFD27E");
        });

        modelBuilder.Entity<ViTriCongViec>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__ViTriCon__27258E7694727587");

            entity.ToTable("ViTriCongViec");

            entity.Property(e => e.MaCv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(50)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.MaXe).HasName("PK__Xe__272520CD1A803A7F");

            entity.ToTable("Xe");

            entity.Property(e => e.MaXe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileAnh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KieuXe).HasMaxLength(50);
            entity.Property(e => e.MaDong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MauSac).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.NamSx)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("NamSX");
            entity.Property(e => e.TenXe).HasMaxLength(50);

            entity.HasOne(d => d.MaDongNavigation).WithMany(p => p.Xes)
                .HasForeignKey(d => d.MaDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Xe__MaDong__4316F928");
        });

        modelBuilder.Entity<YeuCauTuVan>(entity =>
        {
            entity.HasKey(e => e.MaYc).HasName("PK__YeuCauTu__27233125B40E3728");

            entity.ToTable("YeuCauTuVan");

            entity.Property(e => e.MaYc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaYC");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayGui).HasColumnType("date");
            entity.Property(e => e.NoiDung).HasMaxLength(200);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.YeuCauTuVans)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCauTuVa__MaNV__72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
