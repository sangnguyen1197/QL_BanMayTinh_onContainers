using System;
using System.Collections.Generic;

namespace DonHang.API.Models
{
    public partial class Donhang
    {
        public Donhang()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
        }

        public string MaDh { get; set; }
        public DateTime? NgayTao { get; set; }
        public string TaiKhoan { get; set; }
        public string Shipname { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public decimal? TongTien { get; set; }
        public int? DaThanhToan { get; set; }
        public int? Status { get; set; }

        public ICollection<Chitietdonhang> Chitietdonhang { get; set; }
    }
}
