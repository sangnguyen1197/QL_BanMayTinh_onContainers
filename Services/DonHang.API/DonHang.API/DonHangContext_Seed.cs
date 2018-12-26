using DonHang.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonHang.API
{
    public class DonHangContext_Seed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QL_BANMAYTINH_DONHANGContext>();

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

                    if (!context.Donhang.Any())
                    {
                        context.Donhang.AddRange(GenerateDonHang());

                        await context.SaveChangesAsync();
                    }

                    if (!context.Chitietdonhang.Any())
                    {
                        context.Chitietdonhang.AddRange(GenerateChiTietDonHang());

                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        static IEnumerable<Donhang> GenerateDonHang()
        {
            return new List<Donhang>()
            {
                new Donhang() { MaDh = "DH001", NgayTao = new DateTime(2018, 3, 1), TaiKhoan = "ngocson",
                    Shipname = "Nguyễn Ngọc Sơn", ShipMobile = "0123456789",
                    ShipAddress = "Quận 12", ShipEmail = "son@gmail.com",
                    TongTien = 161910000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH002", NgayTao = new DateTime(2018, 3, 12), TaiKhoan = "thanhtan",
                    Shipname = "Huỳnh Thanh Tân", ShipMobile = "0987654321",
                    ShipAddress = "Quận 5", ShipEmail = "tan@gmail.com",
                    TongTien = 95730000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH003", NgayTao = new DateTime(2018, 3, 18), TaiKhoan = "ngocson",
                    Shipname = "Nguyễn Ngọc Sơn", ShipMobile = "0123456789",
                    ShipAddress = "Quận 12", ShipEmail = "son@gmail.com",
                    TongTien = 46470000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH004", NgayTao = new DateTime(2018, 3, 20), TaiKhoan = "khanhphuong",
                    Shipname = "Khánh Phương", ShipMobile = "0721634189",
                    ShipAddress = "Quận 1", ShipEmail = "phuong@gmail.com",
                    TongTien = 81140000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH005", NgayTao = new DateTime(2018, 3, 24), TaiKhoan = "hoavinh",
                    Shipname = "Hoa Vinh", ShipMobile = "0641882694",
                    ShipAddress = "Quận 8", ShipEmail = "vinh@gmail.com",
                    TongTien = 80760000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH006", NgayTao = new DateTime(2018, 3, 27), TaiKhoan = "camly",
                    Shipname = "Cẩm Ly", ShipMobile = "0482615796",
                    ShipAddress = "Quận 2", ShipEmail = "ly@gmail.com",
                    TongTien = 17290000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH007", NgayTao = new DateTime(2018, 3, 30), TaiKhoan = "huongtram",
                    Shipname = "Hương Tràm", ShipMobile = "0562148637",
                    ShipAddress = "Quận 2", ShipEmail = "tram@gmail.com",
                    TongTien = 53450000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH008", NgayTao = new DateTime(2018, 4, 7), TaiKhoan = "nhusang",
                    Shipname = "Nguyễn Như Sang", ShipMobile = "0521364890",
                    ShipAddress = "Quận 12", ShipEmail = "sang@gmail.com",
                    TongTien = 16040000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH009", NgayTao = new DateTime(2018, 4, 21), TaiKhoan = "thudiep",
                    Shipname = "Trần Thu Diệp", ShipMobile = "0946251674",
                    ShipAddress = "Quận 3", ShipEmail = "diep@gmail.com",
                    TongTien = 89330000, DaThanhToan = 1, Status = 1 },
                new Donhang() { MaDh = "DH010", NgayTao = new DateTime(2018, 5, 10), TaiKhoan = "thudiep",
                    Shipname = "Trần Thu Diệp", ShipMobile = "0946251674",
                    ShipAddress = "Quận 3", ShipEmail = "diep@gmail.com",
                    TongTien = 17290000, DaThanhToan = 1, Status = 1 }
            };
        }

        static IEnumerable<Chitietdonhang> GenerateChiTietDonHang()
        {
            return new List<Chitietdonhang>()
            {
                new Chitietdonhang() { MaDh = "DH001", MaSp = "SP001",
                    SoLuong = 3, ThanhTien = 38970000 },
                new Chitietdonhang() { MaDh = "DH001", MaSp = "SP005",
                    SoLuong = 2, ThanhTien = 45980000 },
                new Chitietdonhang() { MaDh = "DH001", MaSp = "SP007",
                    SoLuong = 3, ThanhTien = 31470000 },
                new Chitietdonhang() { MaDh = "DH001", MaSp = "SP002",
                    SoLuong = 1, ThanhTien = 45490000 },
                new Chitietdonhang() { MaDh = "DH002", MaSp = "SP006",
                    SoLuong = 3, ThanhTien = 41370000 },
                new Chitietdonhang() { MaDh = "DH002", MaSp = "SP009",
                    SoLuong = 2, ThanhTien = 21980000 },
                new Chitietdonhang() { MaDh = "DH002", MaSp = "SP010",
                    SoLuong = 1, ThanhTien = 17490000 },
                new Chitietdonhang() { MaDh = "DH002", MaSp = "SP016",
                    SoLuong = 1, ThanhTien = 14890000 },
                new Chitietdonhang() { MaDh = "DH003", MaSp = "SP015",
                    SoLuong = 3, ThanhTien = 46470000 },
                new Chitietdonhang() { MaDh = "DH004", MaSp = "SP014",
                    SoLuong = 2, ThanhTien = 25980000 },
                new Chitietdonhang() { MaDh = "DH004", MaSp = "SP011",
                    SoLuong = 2, ThanhTien = 20580000 },
                new Chitietdonhang() { MaDh = "DH004", MaSp = "SP001",
                    SoLuong = 2, ThanhTien = 34580000 },
                new Chitietdonhang() { MaDh = "DH005", MaSp = "SP005",
                    SoLuong = 2, ThanhTien = 34780000 },
                new Chitietdonhang() { MaDh = "DH005", MaSp = "SP003",
                    SoLuong = 2, ThanhTien = 45980000 },
                new Chitietdonhang() { MaDh = "DH006", MaSp = "SP014",
                    SoLuong = 1, ThanhTien = 17290000 },
                new Chitietdonhang() { MaDh = "DH007", MaSp = "SP011",
                    SoLuong = 1, ThanhTien = 10290000 },
                new Chitietdonhang() { MaDh = "DH007", MaSp = "SP013",
                    SoLuong = 4, ThanhTien = 43160000 },
                new Chitietdonhang() { MaDh = "DH008", MaSp = "SP006",
                    SoLuong = 1, ThanhTien = 13790000 },
                new Chitietdonhang() { MaDh = "DH008", MaSp = "SP008",
                    SoLuong = 3, ThanhTien = 2250000 },
                new Chitietdonhang() { MaDh = "DH009", MaSp = "SP009",
                    SoLuong = 2, ThanhTien = 21980000 },
                new Chitietdonhang() { MaDh = "DH009", MaSp = "SP010",
                    SoLuong = 2, ThanhTien = 34980000 },
                new Chitietdonhang() { MaDh = "DH009", MaSp = "SP013",
                    SoLuong = 3, ThanhTien = 32370000 },
                new Chitietdonhang() { MaDh = "DH010", MaSp = "SP014",
                    SoLuong = 1, ThanhTien = 17290000 }
            };
        }
    }
}
