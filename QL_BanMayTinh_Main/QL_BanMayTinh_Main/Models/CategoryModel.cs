using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class CategoryModel
    {
        [Key]
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryValue { get; set; }

        public bool IsChecked { get; set; }
    }
}
