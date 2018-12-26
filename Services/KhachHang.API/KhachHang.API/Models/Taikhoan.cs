using System;
using System.Collections.Generic;

namespace KhachHang.API.Models
{
    public partial class Taikhoan
    {
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Quyen { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public int? Flag { get; set; }
    }
}
