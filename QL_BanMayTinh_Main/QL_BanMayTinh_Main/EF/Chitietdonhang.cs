using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Chitietdonhang
    {
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Mã đơn hàng")]
        [StringLength(50)]
        public string MaDh { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string MaSp { get; set; }

        [Range(1, 1000, ErrorMessage = "Số lượng sản phẩm không hợp lệ")]
        [Required(ErrorMessage = "Vui lòng nhập vào số lượng sản phẩm")]
        [Display(Name = "Số lượng mua")]
        public int? SoLuong { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? ThanhTien { get; set; }

        public Donhang MaDhNavigation { get; set; }
        public Sanpham MaSpNavigation { get; set; }
    }
}
