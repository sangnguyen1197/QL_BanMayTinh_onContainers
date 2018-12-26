using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SanPham.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanPham.API
{
    public class SanPhamContext_Seed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QL_BANMAYTINH_SANPHAMContext>();

                using (context)
                {
                    // Create database if not exists
                    context.Database.Migrate();

                    // Create tables if not exists
                    try
                    {
                        var databaseCreator = context.GetService<IRelationalDatabaseCreator>();
                        databaseCreator.CreateTables();
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }

                    // Check if a table has any data
                    if (!context.Thuonghieu.Any())
                    {
                        context.Thuonghieu.AddRange(GenerateThuongHieu());

                        await context.SaveChangesAsync();
                    }

                    if (!context.Sanpham.Any())
                    {
                        context.Sanpham.AddRange(GenerateSanPham());

                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        static IEnumerable<Thuonghieu> GenerateThuongHieu()
        {
            return new List<Thuonghieu>()
            {
                new Thuonghieu() { MaThuongHieu = "ASUS", TenThuongHieu = "Thương hiệu laptop ASUS" },
                new Thuonghieu() { MaThuongHieu = "DELL", TenThuongHieu = "Thương hiệu laptop DELL" },
                new Thuonghieu() { MaThuongHieu = "HP", TenThuongHieu = "Thương hiệu laptop HP" },
                new Thuonghieu() { MaThuongHieu = "ACER", TenThuongHieu = "Thương hiệu laptop ACER" }
            };
        }

        static IEnumerable<Sanpham> GenerateSanPham()
        {
            return new List<Sanpham>()
            {
                new Sanpham() { MaSp = "SP001", TenSp = "Laptop Asus VivoBook S15 S510UA", MaThuongHieu = "ASUS",
                    SoLuongTon = 15, GiaBanLe = 12990000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM: 4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: HDD: 1 TB SATA3*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa tích hợp, Intel® UHD Graphics 620",
                    Hinhanh = "/products/asus-vivobook-s15-s510ua.jpg",
                    Hinhanhindex = "/products/asus-vivobook-s15-s510ua-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP002", TenSp = "Laptop Asus ROG Strix Scar GL504GM", MaThuongHieu = "ASUS",
                    SoLuongTon = 14, GiaBanLe = 45490000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i7 Coffee Lake, 8750H, 2.20 GHz*RAM: 16 GB, DDR4 (2 khe), 2666 MHz*Ổ cứng: HDD: 1 TB + SSD: 128GB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa rời, NVIDIA GeForce GTX1060, 6GB",
                    Hinhanh = "/products/asus-rog-strix-scar-gl504gm.jpg",
                    Hinhanhindex = "/products/asus-rog-strix-scar-gl504gm-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP003", TenSp = "Laptop Asus Vivobook S15 S530UA", MaThuongHieu = "ASUS",
                    SoLuongTon = 8, GiaBanLe = 17390000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU:Intel Core i5 Coffee Lake, 8250U, 1.60 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 SATA3, Intel Optane 16GB*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620",
                    Hinhanh = "/products/asus-vivobook-s15-s530ua.jpg",
                    Hinhanhindex = "/products/asus-vivobook-s15-s530ua-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP004", TenSp = "Laptop Asus VivoBook X540UB", MaThuongHieu = "ASUS",
                    SoLuongTon = 20, GiaBanLe = 11290000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Skylake, 6006U, 2.00 GHz*RAM: 4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng: HDD: 1 TB*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa rời, NVIDIA GeForce MX110, 2GB",
                    Hinhanh = "/products/asus-vivobook-x540ub.jpg",
                    Hinhanhindex = "/products/asus-vivobook-x540ub-index.jpg", TrangThai = "1" },

                new Sanpham() { MaSp = "SP005", TenSp = "Laptop Dell Inspiron 7570", MaThuongHieu = "DELL",
                    SoLuongTon = 6, GiaBanLe = 22990000, XuatSu = "USA",
                    Motakithuat = "CPU: Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM: 4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: HDD: 1 TB + SSD: 128GB, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa rời, NVIDIA GeForce 940MX, 4 GB",
                    Hinhanh = "/products/dell-inspiron-7570.jpg",
                    Hinhanhindex = "/products/dell-inspiron-7570-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP006", TenSp = "Laptop Dell Vostro 3468", MaThuongHieu = "DELL",
                    SoLuongTon = 16, GiaBanLe = 13790000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i5 Kabylake, 7200U, 2.50 GHz*RAM: 4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: HDD: 1 TB*Màn hình: 14 inch, HD (1366 x 768)*Card màn hình: Card đồ họa tích hợp, Intel® HD Graphics 620",
                    Hinhanh = "/products/dell-vostro-3468.jpg",
                    Hinhanhindex = "/products/dell-vostro-3468-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP007", TenSp = "Laptop Dell Inspiron 7373", MaThuongHieu = "DELL",
                    SoLuongTon = 7, GiaBanLe = 10490000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM: 8 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: SSD: 256 GB*Màn hình: 13.3 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa tích hợp, Intel® UHD Graphics 620",
                    Hinhanh = "/products/dell-inspiron-7373.jpg",
                    Hinhanhindex = "/products/dell-inspiron-7373-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP008", TenSp = "Laptop DELL Inspiron 15 N3567", MaThuongHieu = "DELL",
                    SoLuongTon = 17, GiaBanLe = 7500000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Skylake, 6006U, 2.00 GHz*RAM: 4 GB, DDR4 (2 khe), 2133 MHz*Ổ cứng: HDD: 1 TB*Màn hình: 15.6 inch, HD (1366 x 768)*Card màn hình: Card đồ họa rời, AMD Radeon R5 M430, 2 GB",
                    Hinhanh = "/products/dell-inspiron-15-n3567.jpg",
                    Hinhanhindex = "/products/dell-inspiron-15-n3567-index.jpg", TrangThai = "1" },

                new Sanpham() { MaSp = "SP009", TenSp = "Laptop HP 15 da0054TU", MaThuongHieu = "HP",
                    SoLuongTon = 16, GiaBanLe = 10990000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Kabylake, 7020U, 2.30 GHz*RAM: 4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng: HDD: 500 GB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa tích hợp, Intel® HD Graphics 620",
                    Hinhanh = "/products/hp-15-da0054tu.jpg",
                    Hinhanhindex = "/products/hp-15-da0054tu-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP010", TenSp = "Laptop HP 15 da0036TX", MaThuongHieu = "HP",
                    SoLuongTon = 7, GiaBanLe = 17490000, XuatSu = "USA",
                    Motakithuat = "CPU: Intel Core i7 Kabylake Refresh, 8550U, 1.80 GHz*RAM: 4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: HDD: 1 TB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa rời, NVIDIA Geforce MX130, 2GB",
                    Hinhanh = "/products/hp-15-da0036tx.jpg",
                    Hinhanhindex = "/products/hp-15-da0036tx-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP011", TenSp = "Laptop HP 15 da0055TU", MaThuongHieu = "HP",
                    SoLuongTon = 12, GiaBanLe = 10290000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Kabylake, 7020U, 2.30 GHz*RAM: 4 GB, DDR4 (1 khe), 2133 MHz*Ổ cứng: HDD: 1 TB*Màn hình: 15.6 inch, HD (1366 x 768)*Card màn hình: Card đồ họa tích hợp, Intel® HD Graphics 620",
                    Hinhanh = "/products/hp-15-da0055tu.jpg",
                    Hinhanhindex = "/products/hp-15-da0055tu-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP012", TenSp = "Laptop HP Pavilion", MaThuongHieu = "HP",
                    SoLuongTon = 20, GiaBanLe = 13490000, XuatSu = "USA",
                    Motakithuat = "CPU: Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM: 4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng: HDD: 1 TB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình: 14 inch, HD (1366 x 768)*Card màn hình: Card đồ họa tích hợp, Intel® UHD Graphics 620",
                    Hinhanh = "/products/hp-pavilion.jpg",
                    Hinhanhindex = "/products/hp-pavilion-index.jpg", TrangThai = "1" },

                new Sanpham() { MaSp = "SP013", TenSp = "Laptop Acer Aspire E5 576 34ND", MaThuongHieu = "ACER",
                    SoLuongTon = 8, GiaBanLe = 10790000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM: 4 GB, DDR3L (2 khe RAM), 2133 MHz*Ổ cứng: HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa tích hợp, Intel® HD Graphics 620",
                    Hinhanh = "/products/acer-aspire-e5-576.jpg",
                    Hinhanhindex = "/products/acer-aspire-e5-576-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP014", TenSp = "Laptop Acer Swift SF314 54 51QL", MaThuongHieu = "ACER",
                    SoLuongTon = 16, GiaBanLe = 17290000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM: 4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng: HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe, Hỗ trợ bộ nhớ Intel® Optane™*Màn hình: 14 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa tích hợp, Intel® HD Graphics 620",
                    Hinhanh = "/products/acer-swift-sf314-5451.jpg",
                    Hinhanhindex = "/products/acer-swift-sf314-5451-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP015", TenSp = "Laptop Acer Swift SF315 51 530V", MaThuongHieu = "ACER",
                    SoLuongTon = 12, GiaBanLe = 15490000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM: 4 GB, DDR4 (On board), 2400 MHz*Ổ cứng: HDD: 1 TB*Màn hình:15.6 inch*Card màn hình: Card đồ họa tích hợp, Intel® UHD Graphics 620",
                    Hinhanh = "/products/acer-swift-sf315-51-530v.jpg",
                    Hinhanhindex = "/products/acer-swift-sf315-51-530v-index.jpg", TrangThai = "1" },
                new Sanpham() { MaSp = "SP016", TenSp = "Laptop Acer Aspire E5 576G 52YQ", MaThuongHieu = "ACER",
                    SoLuongTon = 39, GiaBanLe = 14890000, XuatSu = "Trung Quốc",
                    Motakithuat = "CPU: Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM: 4 GB, DDR3L (2 khe RAM), 1600 MHz*Ổ cứng: HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình: 15.6 inch, Full HD (1920 x 1080)*Card màn hình: Card đồ họa rời, NVIDIA Geforce MX130, 2GB",
                    Hinhanh = "/products/acer-aspire-e5-576g52.jpg",
                    Hinhanhindex = "/products/acer-aspire-e5-576g52-index.jpg", TrangThai = "1" }
            };
        }
    }
}
