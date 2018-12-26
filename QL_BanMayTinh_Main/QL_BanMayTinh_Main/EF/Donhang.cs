using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Donhang
    {
        public Donhang()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Mã đơn hàng")]
        public string MaDh { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo ĐH")]
        public DateTime NgayTao { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(50), MinLength(5, ErrorMessage = "Tên tối thiểu chứa 5 kí tự"), MaxLength(40, ErrorMessage = "Tên vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập tên")]
        [Display(Name = "Tên người đặt hàng")]
        public string Shipname { get; set; }

        [StringLength(100), MinLength(10, ErrorMessage = "Số điện thoại tối thiểu chứa 10 kí tự"), MaxLength(13, ErrorMessage = "Số điện thoại vượt quá độ dài cho phép")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "SĐT đặt hàng")]
        public string ShipMobile { get; set; }
        
        [StringLength(100), MinLength(5, ErrorMessage = "Địa chỉ tối thiểu chứa 5 kí tự"), MaxLength(80, ErrorMessage = "Địa chỉ vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập vào địa chỉ giao hàng")]
        [Display(Name = "Địa chỉ đặt hàng")]
        public string ShipAddress { get; set; }

        [StringLength(100), MaxLength(30, ErrorMessage = "Địa chỉ mail vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập vào địa chỉ mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Sai định dạng! Địa chỉ mail ví dụ: tanht1997@gmail.com")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email đặt hàng")]
        public string ShipEmail { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? TongTien { get; set; }

        [Display(Name = "Tình trạng thanh toán")]
        public int? DaThanhToan { get; set; }
        public int? Status { get; set; }

        public Taikhoan TaiKhoanNavigation { get; set; }
        public ICollection<Chitietdonhang> Chitietdonhang { get; set; }
    }
}
