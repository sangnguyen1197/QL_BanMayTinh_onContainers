using QL_BanMayTinh_Main.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanMayTinh_Main.Models
{
    public class SearchModel
    {
        public List<Sanpham> SearchResult { get; set; }

        public FilterModel filter { get; set; }
    }
}
