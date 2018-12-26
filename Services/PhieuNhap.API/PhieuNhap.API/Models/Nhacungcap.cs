using System;
using System.Collections.Generic;

namespace PhieuNhap.API.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Phieunhap = new HashSet<Phieunhap>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public int? Flag { get; set; }

        public ICollection<Phieunhap> Phieunhap { get; set; }
    }
}
