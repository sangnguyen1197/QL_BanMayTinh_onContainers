using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Donhang = new HashSet<Donhang>();
        }

        [Key]
        [Column("TaiKhoan")]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string TaiKhoan1 { get; set; }

        [Required]
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(100), MaxLength(30, ErrorMessage = "Địa chỉ mail vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập vào địa chỉ mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Sai định dạng! Địa chỉ mail ví dụ: tanht1997@gmail.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Quyen { get; set; }

        [StringLength(50), MinLength(5, ErrorMessage = "Tên tối thiểu chứa 5 kí tự"), MaxLength(40, ErrorMessage = "Tên vượt quá độ dài cho phép"), Required(ErrorMessage = "Vui lòng nhập tên")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100), MinLength(10, ErrorMessage = "Số điện thoại tối thiểu chứa 10 kí tự"), MaxLength(13, ErrorMessage = "Số điện thoại vượt quá độ dài cho phép")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }

        [StringLength(100), MaxLength(80, ErrorMessage = "Địa chỉ vượt quá độ dài cho phép")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public int? Flag { get; set; }

        public ICollection<Donhang> Donhang { get; set; }
    }
}
