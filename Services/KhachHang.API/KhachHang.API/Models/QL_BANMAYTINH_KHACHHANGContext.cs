using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KhachHang.API.Models
{
    public partial class QL_BANMAYTINH_KHACHHANGContext : DbContext
    {
        public QL_BANMAYTINH_KHACHHANGContext()
        {
        }

        public QL_BANMAYTINH_KHACHHANGContext(DbContextOptions<QL_BANMAYTINH_KHACHHANGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Taikhoan> Taikhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan1);

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TaiKhoan1)
                    .HasColumnName("TaiKhoan")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Quyen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
