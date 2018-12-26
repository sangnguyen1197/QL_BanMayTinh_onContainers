using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DonHang.API.Models
{
    public partial class QL_BANMAYTINH_DONHANGContext : DbContext
    {
        public QL_BANMAYTINH_DONHANGContext()
        {
        }

        public QL_BANMAYTINH_DONHANGContext(DbContextOptions<QL_BANMAYTINH_DONHANGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhang { get; set; }
        public virtual DbSet<Donhang> Donhang { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.HasKey(e => new { e.MaDh, e.MaSp });

                entity.ToTable("CHITIETDONHANG");

                entity.Property(e => e.MaDh)
                    .HasColumnName("MaDH")
                    .HasMaxLength(50);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(19, 3)");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.Chitietdonhang)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETDON__MaDH__1273C1CD");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.ToTable("DONHANG");

                entity.Property(e => e.MaDh)
                    .HasColumnName("MaDH")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.ShipAddress).HasMaxLength(50);

                entity.Property(e => e.ShipEmail).HasMaxLength(50);

                entity.Property(e => e.ShipMobile).HasMaxLength(50);

                entity.Property(e => e.Shipname).HasMaxLength(50);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TongTien).HasColumnType("decimal(19, 3)");
            });
        }
    }
}
