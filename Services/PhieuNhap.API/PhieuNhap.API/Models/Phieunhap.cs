using System;
using System.Collections.Generic;

namespace PhieuNhap.API.Models
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Chitietphieunhap = new HashSet<Chitietphieunhap>();
        }

        public string MaPn { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string MaNcc { get; set; }
        public decimal? TongTien { get; set; }
        public int? Flag { get; set; }

        public Nhacungcap MaNccNavigation { get; set; }
        public ICollection<Chitietphieunhap> Chitietphieunhap { get; set; }
    }
}
