using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhieuNhap.API.Models
{
    public partial class QL_BANMAYTINH_PHIEUNHAPContext : DbContext
    {
        public QL_BANMAYTINH_PHIEUNHAPContext()
        {
        }

        public QL_BANMAYTINH_PHIEUNHAPContext(DbContextOptions<QL_BANMAYTINH_PHIEUNHAPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietphieunhap> Chitietphieunhap { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Phieunhap> Phieunhap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietphieunhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPn, e.MaSp });

                entity.ToTable("CHITIETPHIEUNHAP");

                entity.Property(e => e.MaPn)
                    .HasColumnName("MaPN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(19, 3)");

                entity.HasOne(d => d.MaPnNavigation)
                    .WithMany(p => p.Chitietphieunhap)
                    .HasForeignKey(d => d.MaPn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPHI__MaPN__15502E78");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasColumnName("TenNCC")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Phieunhap>(entity =>
            {
                entity.HasKey(e => e.MaPn);

                entity.ToTable("PHIEUNHAP");

                entity.Property(e => e.MaPn)
                    .HasColumnName("MaPN")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNhap).HasColumnType("date");

                entity.Property(e => e.TongTien).HasColumnType("decimal(19, 3)");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Phieunhap)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK__PHIEUNHAP__MaNCC__1273C1CD");
            });
        }
    }
}
