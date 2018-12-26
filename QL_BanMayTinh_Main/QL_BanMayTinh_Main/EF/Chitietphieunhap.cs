using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Chitietphieunhap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        [Display(Name = "Mã phiếu nhập")]
        public string MaPn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string MaSp { get; set; }

        [Range(1, 1000, ErrorMessage = "Số lượng sản phẩm không hợp lệ")]
        [Required(ErrorMessage = "Vui lòng nhập vào số lượng sản phẩm")]
        [Display(Name = "Số lượng sản phẩm")]
        public int? SoLuongNhap { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? ThanhTien { get; set; }

        public Phieunhap MaPnNavigation { get; set; }
        public Sanpham MaSpNavigation { get; set; }
    }
}
