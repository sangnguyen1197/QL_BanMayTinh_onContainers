using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class PriceModel
    {
        [Key]
        public string PriceID { get; set; }

        public string PriceName { get; set; }

        public string PriceValue { get; set; }

        public bool IsChecked { get; set; }
    }
}
