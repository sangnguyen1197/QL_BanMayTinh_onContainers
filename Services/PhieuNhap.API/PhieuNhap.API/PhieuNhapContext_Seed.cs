using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using PhieuNhap.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhieuNhap.API
{
    public class PhieuNhapContext_Seed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QL_BANMAYTINH_PHIEUNHAPContext>();

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
                    if (!context.Nhacungcap.Any())
                    {
                        context.Nhacungcap.AddRange(GenerateNhaCungCap());

                        await context.SaveChangesAsync();
                    }

                    if (!context.Phieunhap.Any())
                    {
                        context.Phieunhap.AddRange(GeneratePhieuNhap());

                        await context.SaveChangesAsync();
                    }

                    if (!context.Chitietphieunhap.Any())
                    {
                        context.Chitietphieunhap.AddRange(GenerateChiTietPhieuNhap());

                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        static IEnumerable<Nhacungcap> GenerateNhaCungCap()
        {
            return new List<Nhacungcap>()
            {
                new Nhacungcap() { MaNcc = "NCC001", TenNcc = "Công ty cửa hàng máy tính phân phối sỉ lẻ HUỲNH ĐỨC",
                    DiaChi = "20/13 Phù Đổng Thiên Vương, P11, Q5, TP.HCM", Sdt = "0984565882", Flag = 1 },
                new Nhacungcap() { MaNcc = "NCC002", TenNcc = "Công ty xuất nhập khẩu máy tính Gia Long",
                    DiaChi = "605 Nguyễn Trãi, P12, Q5, TP.HCM", Sdt = "0986889320", Flag = 1 },
                new Nhacungcap() { MaNcc = "NCC003", TenNcc = "Đại lí máy tính DELLX9",
                    DiaChi = "61/2 Cách Mạng Tháng Tám, P6, Q3, TP.HCM", Sdt = "0124526997", Flag = 1 },
                new Nhacungcap() { MaNcc = "NCC004", TenNcc = "Cửa hàng buôn bán máy tính QUỲNH NHI",
                    DiaChi = "853/4 D2, P1, Q10, TP.HCM", Sdt = "0984789550", Flag = 1 },
                new Nhacungcap() { MaNcc = "NCC005", TenNcc = "Công ty đại lí phân phối sản phẩn máy tính ASUS9",
                    DiaChi = "61/1 Phạm Hữu Lầu, P2, Q8, TP.HCM", Sdt = "0165895325", Flag = 1 }
            };
        }

        static IEnumerable<Phieunhap> GeneratePhieuNhap()
        {
            return new List<Phieunhap>()
            {
                new Phieunhap() { MaPn = "PN001", NgayNhap = new DateTime(2015, 12, 7), MaNcc = "NCC001",
                    TongTien = 433700000, Flag = 1 },
                new Phieunhap() { MaPn = "PN002", NgayNhap = new DateTime(2016, 1, 1), MaNcc = "NCC002",
                    TongTien = 908150000, Flag = 1 },
                new Phieunhap() { MaPn = "PN003", NgayNhap = new DateTime(2016, 4, 6), MaNcc = "NCC004",
                    TongTien = 610600000, Flag = 1 },
                new Phieunhap() { MaPn = "PN004", NgayNhap = new DateTime(2016, 6, 11), MaNcc = "NCC005",
                    TongTien = 234800000, Flag = 1 },
                new Phieunhap() { MaPn = "PN005", NgayNhap = new DateTime(2016, 7, 5), MaNcc = "NCC003",
                    TongTien = 174900000, Flag = 1 },
                new Phieunhap() { MaPn = "PN006", NgayNhap = new DateTime(2016, 11, 21), MaNcc = "NCC004",
                    TongTien = 154350000, Flag = 1 },
                new Phieunhap() { MaPn = "PN007", NgayNhap = new DateTime(2017, 5, 6), MaNcc = "NCC001",
                    TongTien = 269800000, Flag = 1 },
                new Phieunhap() { MaPn = "PN008", NgayNhap = new DateTime(2017, 6, 12), MaNcc = "NCC002",
                    TongTien = 161850000, Flag = 1 },
                new Phieunhap() { MaPn = "PN009", NgayNhap = new DateTime(2017, 7, 12), MaNcc = "NCC005",
                    TongTien = 345800000, Flag = 1 },
                new Phieunhap() { MaPn = "PN010", NgayNhap = new DateTime(2017, 12, 31), MaNcc = "NCC001",
                    TongTien = 232350000, Flag = 1 },
                new Phieunhap() { MaPn = "PN011", NgayNhap = new DateTime(2018, 1, 11), MaNcc = "NCC003",
                    TongTien = 297800000, Flag = 1 },
                new Phieunhap() { MaPn = "PN012", NgayNhap = new DateTime(2018, 3, 2), MaNcc = "NCC002",
                    TongTien = 297800000, Flag = 1 }
            };
        }

        static IEnumerable<Chitietphieunhap> GenerateChiTietPhieuNhap()
        {
            return new List<Chitietphieunhap>()
            {
                new Chitietphieunhap() { MaPn = "PN001", MaSp = "SP001",
                    SoLuongNhap = 20, ThanhTien = 259800000 },
                new Chitietphieunhap() { MaPn = "PN001", MaSp = "SP003",
                    SoLuongNhap = 10, ThanhTien = 173900000 },
                new Chitietphieunhap() { MaPn = "PN002", MaSp = "SP002",
                    SoLuongNhap = 15, ThanhTien = 682350000 },
                new Chitietphieunhap() { MaPn = "PN002", MaSp = "SP004",
                    SoLuongNhap = 20, ThanhTien = 225800000 },
                new Chitietphieunhap() { MaPn = "PN003", MaSp = "SP005",
                    SoLuongNhap = 10, ThanhTien = 229900000 },
                new Chitietphieunhap() { MaPn = "PN003", MaSp = "SP006",
                    SoLuongNhap = 20, ThanhTien = 275800000 },
                new Chitietphieunhap() { MaPn = "PN003", MaSp = "SP007",
                    SoLuongNhap = 10, ThanhTien = 104900000 },
                new Chitietphieunhap() { MaPn = "PN004", MaSp = "SP008",
                    SoLuongNhap = 20, ThanhTien = 15000000 },
                new Chitietphieunhap() { MaPn = "PN004", MaSp = "SP009",
                    SoLuongNhap = 20, ThanhTien = 219800000 },
                new Chitietphieunhap() { MaPn = "PN005", MaSp = "SP010",
                    SoLuongNhap = 10, ThanhTien = 174900000 },
                new Chitietphieunhap() { MaPn = "PN006", MaSp = "SP011",
                    SoLuongNhap = 15, ThanhTien = 154350000 },
                new Chitietphieunhap() { MaPn = "PN007", MaSp = "SP012",
                    SoLuongNhap = 10, ThanhTien = 173900000 },
                new Chitietphieunhap() { MaPn = "PN008", MaSp = "SP013",
                    SoLuongNhap = 15, ThanhTien = 161850000 },
                new Chitietphieunhap() { MaPn = "PN009", MaSp = "SP014",
                    SoLuongNhap = 20, ThanhTien = 345800000 },
                new Chitietphieunhap() { MaPn = "PN010", MaSp = "SP015",
                    SoLuongNhap = 15, ThanhTien = 232350000 },
                new Chitietphieunhap() { MaPn = "PN011", MaSp = "SP016",
                    SoLuongNhap = 20, ThanhTien = 297800000 },
                new Chitietphieunhap() { MaPn = "PN012", MaSp = "SP016",
                    SoLuongNhap = 15, ThanhTien = 297800000 }
            };
        }
    }
}
