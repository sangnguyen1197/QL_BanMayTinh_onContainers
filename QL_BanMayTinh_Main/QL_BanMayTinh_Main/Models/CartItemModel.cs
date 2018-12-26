using QL_BanMayTinh_Main.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    [Serializable]
    public class CartItemModel
    {
        public Sanpham sanpham { get; set; }

        public int soluong { get; set; }
    }
}
