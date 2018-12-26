using System;
using System.Collections.Generic;

namespace DonHang.API.Models
{
    public partial class Chitietdonhang
    {
        public string MaDh { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }

        public Donhang MaDhNavigation { get; set; }
    }
}
