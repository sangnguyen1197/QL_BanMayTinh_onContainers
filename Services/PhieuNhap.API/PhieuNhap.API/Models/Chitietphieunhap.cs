using System;
using System.Collections.Generic;

namespace PhieuNhap.API.Models
{
    public partial class Chitietphieunhap
    {
        public string MaPn { get; set; }
        public string MaSp { get; set; }
        public int? SoLuongNhap { get; set; }
        public decimal? ThanhTien { get; set; }

        public Phieunhap MaPnNavigation { get; set; }
    }
}
