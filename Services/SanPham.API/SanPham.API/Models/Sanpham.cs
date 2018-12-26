using System;
using System.Collections.Generic;

namespace SanPham.API.Models
{
    public partial class Sanpham
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MaThuongHieu { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? GiaBanLe { get; set; }
        public string XuatSu { get; set; }
        public string Motakithuat { get; set; }
        public string Hinhanh { get; set; }
        public string Hinhanhindex { get; set; }
        public string TrangThai { get; set; }

        public Thuonghieu MaThuongHieuNavigation { get; set; }
    }
}
