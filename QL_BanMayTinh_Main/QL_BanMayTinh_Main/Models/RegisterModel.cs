using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class RegisterModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [StringLength(50)]
        public string TaiKhoan1 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20, ErrorMessage = "Độ dài mật khẩu phải có ít nhất 6 kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Sai định dạng! Địa chỉ mail ví dụ: tanht1997@gmail.com")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
        public string Email { get; set; }

        [StringLength(50), MinLength(5, ErrorMessage = "Tên tối thiểu chứa 5 kí tự"), MaxLength(40, ErrorMessage = "Tên vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập tên"), DataType("varchar")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        public Gender GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày/tháng/năm sinh")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [StringLength(100), MinLength(10, ErrorMessage = "Số điện thoại tối thiểu chứa 10 kí tự"), MaxLength(13, ErrorMessage = "Số điện thoại vượt quá độ dài cho phép"), DataType("varchar")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }

        [StringLength(100), MaxLength(80, ErrorMessage = "Địa chỉ vượt quá độ dài cho phép"), DataType("varchar")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
