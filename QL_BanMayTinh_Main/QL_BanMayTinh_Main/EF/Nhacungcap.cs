using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Phieunhap = new HashSet<Phieunhap>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã nhà cung cấp")]
        public string MaNcc { get; set; }

        [Display(Name = "Tên nhà cung cấp")]
        [StringLength(100), Required(ErrorMessage = "Vui lòng nhập vào tên nhà cung cấp")]
        public string TenNcc { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(15)]
        public string Sdt { get; set; }

        public int? Flag { get; set; }

        public ICollection<Phieunhap> Phieunhap { get; set; }
    }
}
