using QL_BanMayTinh_Main.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class HomeViewModel
    {
        public List<Thuonghieu> ViewThuongHieu { get; set; }

        public List<Sanpham> ViewSanPham { get; set; }

        public FilterModel myfilter { get; set; }
    }
}
