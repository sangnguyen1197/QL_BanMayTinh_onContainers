using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class LoginModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string password { get; set; }
    }
}
