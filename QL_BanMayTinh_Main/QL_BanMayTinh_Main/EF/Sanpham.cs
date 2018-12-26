using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
            Chitietphieunhap = new HashSet<Chitietphieunhap>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string MaSp { get; set; }

        [StringLength(100), Required(ErrorMessage = "Vui lòng nhập vào tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSp { get; set; }

        [StringLength(10)]
        [Display(Name = "Thương hiệu")]
        public string MaThuongHieu { get; set; }

        [Display(Name = "SL tồn trong kho")]
        public int? SoLuongTon { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập vào giá tiền")]
        [Range(5000000, 50000000, ErrorMessage = "Giá bán từ 5000000 đến 50000000")]
        [Display(Name = "Giá bán")]
        public decimal GiaBanLe { get; set; }

        [StringLength(20)]
        [Display(Name = "Xuất xứ")]
        public string XuatSu { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả kĩ thuật")]
        public string Motakithuat { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình ảnh chi tiết")]
        public string Hinhanh { get; set; }

        [Display(Name = "Hình ảnh mẫu")]
        [StringLength(100)]
        public string Hinhanhindex { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public Thuonghieu MaThuongHieuNavigation { get; set; }
        public ICollection<Chitietdonhang> Chitietdonhang { get; set; }
        public ICollection<Chitietphieunhap> Chitietphieunhap { get; set; }
    }
}
