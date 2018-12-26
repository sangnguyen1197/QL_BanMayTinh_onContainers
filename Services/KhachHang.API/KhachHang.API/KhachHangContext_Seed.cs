using KhachHang.API.Common;
using KhachHang.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhachHang.API
{
    public class KhachHangContext_Seed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QL_BANMAYTINH_KHACHHANGContext>();

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
                    if (!context.Taikhoan.Any())
                    {
                        context.Taikhoan.AddRange(GenerateTaiKhoan());

                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        static IEnumerable<Taikhoan> GenerateTaiKhoan()
        {
            return new List<Taikhoan>()
            {
                new Taikhoan() { TaiKhoan1 = "admin", MatKhau = SHA1_Encryptor.HashSHA1("admin"), Email = "admin@gmail.com",
                    Quyen = "1", HoTen = "admin", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 11, 25), Sdt = "",
                    DiaChi = "", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "ngocson", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "son@gmail.com",
                    Quyen = "2", HoTen = "Nguyễn Ngọc Sơn", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 11, 25), Sdt = "0123456789",
                    DiaChi = "Quận 12", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "thanhtan", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "tan@gmail.com",
                    Quyen = "2", HoTen = "Huỳnh Thanh Tân", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 3, 3), Sdt = "0987654321",
                    DiaChi = "Quận 5", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "nhusang", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "sang@gmail.com",
                    Quyen = "2", HoTen = "Nguyễn Như Sang", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 2, 2), Sdt = "0521364890",
                    DiaChi = "Quận 3", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "havi", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "vi@gmail.com",
                    Quyen = "2", HoTen = "Nguyễn Thị Hà Vi", GioiTinh = "Nữ", NgaySinh = new DateTime(1997, 9, 9), Sdt = "0124953017",
                    DiaChi = "Quận 1", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "thudiep", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "diep@gmail.com",
                    Quyen = "2", HoTen = "Trần Thu Diệp", GioiTinh = "Nữ", NgaySinh = new DateTime(1997, 9, 23), Sdt = "0946251674",
                    DiaChi = "Quận 3", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "huongtram", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "tram@gmail.com",
                    Quyen = "2", HoTen = "Hương Tràm", GioiTinh = "Nữ", NgaySinh = new DateTime(1997, 4, 1), Sdt = "0562148637",
                    DiaChi = "Quận 2", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "khanhphuong", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "phuong@gmail.com",
                    Quyen = "2", HoTen = "Khánh Phương", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 8, 12), Sdt = "0721634189",
                    DiaChi = "Quận 1", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "jangmi", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "jangmi@gmail.com",
                    Quyen = "2", HoTen = "Jang Mi", GioiTinh = "Nữ", NgaySinh = new DateTime(1997, 5, 11), Sdt = "0426841263",
                    DiaChi = "Quận 7", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "hoavinh", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "vinh@gmail.com",
                    Quyen = "2", HoTen = "Hoa Vinh", GioiTinh = "Nam", NgaySinh = new DateTime(1997, 12, 7), Sdt = "0641882694",
                    DiaChi = "Quận 8", Flag = 1 },
                new Taikhoan() { TaiKhoan1 = "camly", MatKhau = SHA1_Encryptor.HashSHA1("123456"), Email = "ly@gmail.com",
                    Quyen = "2", HoTen = "Cẩm Ly", GioiTinh = "Nữ", NgaySinh = new DateTime(1997, 6, 14), Sdt = "0482615796",
                    DiaChi = "Quận 2", Flag = 1 }
            };
        }
    }
}
