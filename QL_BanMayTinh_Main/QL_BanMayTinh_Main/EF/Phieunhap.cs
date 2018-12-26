using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QL_BanMayTinh_Main.EF
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Chitietphieunhap = new HashSet<Chitietphieunhap>();
        }

        [Key]
        [Display(Name = "Mã phiếu nhập")]
        [StringLength(10)]
        public string MaPn { get; set; }

        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        public DateTime? NgayNhap { get; set; }

        [Display(Name = "Tên nhà cung cấp")]
        [StringLength(10)]
        public string MaNcc { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? TongTien { get; set; }

        public int? Flag { get; set; }

        public Nhacungcap MaNccNavigation { get; set; }
        public ICollection<Chitietphieunhap> Chitietphieunhap { get; set; }
    }
}
