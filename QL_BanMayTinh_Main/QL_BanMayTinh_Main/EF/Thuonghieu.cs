using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã thương hiệu")]
        public string MaThuongHieu { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên thương hiệu")]
        public string TenThuongHieu { get; set; }

        public ICollection<Sanpham> Sanpham { get; set; }
    }
}
