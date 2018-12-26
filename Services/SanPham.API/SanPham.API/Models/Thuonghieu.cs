using System;
using System.Collections.Generic;

namespace SanPham.API.Models
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public string MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }

        public ICollection<Sanpham> Sanpham { get; set; }
    }
}
