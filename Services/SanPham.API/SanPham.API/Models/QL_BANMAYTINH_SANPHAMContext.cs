using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SanPham.API.Models
{
    public partial class QL_BANMAYTINH_SANPHAMContext : DbContext
    {
        public QL_BANMAYTINH_SANPHAMContext()
        {
        }

        public QL_BANMAYTINH_SANPHAMContext(DbContextOptions<QL_BANMAYTINH_SANPHAMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SANPHAM");

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GiaBanLe).HasColumnType("decimal(19, 3)");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hinhanhindex)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaThuongHieu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Motakithuat).HasMaxLength(1000);

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasColumnName("TenSP")
                    .HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasMaxLength(20);

                entity.Property(e => e.XuatSu).HasMaxLength(20);

                entity.HasOne(d => d.MaThuongHieuNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.MaThuongHieu)
                    .HasConstraintName("FK__SANPHAM__MaThuon__1273C1CD");
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.HasKey(e => e.MaThuongHieu);

                entity.ToTable("THUONGHIEU");

                entity.Property(e => e.MaThuongHieu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TenThuongHieu).HasMaxLength(50);
            });
        }
    }
}
