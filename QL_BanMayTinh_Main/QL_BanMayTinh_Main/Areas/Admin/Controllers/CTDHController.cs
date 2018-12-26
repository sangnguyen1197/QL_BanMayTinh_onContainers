using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using X.PagedList;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CTDHController : Controller
    {
        static HttpClient GetAPI(string address)
        {
            HttpClient client = new HttpClient();

            Uri apiAddress = new Uri(Environment.GetEnvironmentVariable(address).ToString());

            client.BaseAddress = apiAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        const string SanPhampath = "api/QLSanPham";

        const string DonHangpath = "api/QLDonHang";

        const string ChiTietDonHangpath = "api/ChiTietDonHang";


        // GET: Admin/TbCTDH
        public async Task<IActionResult> Index(string id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            ViewBag.TongTien = list_donhang.Where(s => s.MaDh == id).FirstOrDefault().TongTien;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.SoLuongSortParm = string.IsNullOrEmpty(sortOrder) ? "slsp_desc" : "";
            ViewBag.ThanhTienSortParm = sortOrder == "thanhtien" ? "thanhtien_desc" : "thanhtien";

            if (id == null)
            {
                return BadRequest();
            }

            var list_chitietdonhang = new List<Chitietdonhang>();

            respond = await GetAPI("DonHangUrl").GetAsync(ChiTietDonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var ctdhJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietdonhang = JsonConvert.DeserializeObject<IEnumerable<Chitietdonhang>>(ctdhJsonString).ToList();
            }

            list_chitietdonhang = list_chitietdonhang.Where(x => x.MaDh == id).ToList();

            foreach (Chitietdonhang ctdh in list_chitietdonhang)
            {
                Sanpham sp = list_sanpham.Find(x => x.MaSp == ctdh.MaSp);

                ctdh.MaSpNavigation = sp;
            }

            ViewBag.madh = id;

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_chitietdonhang = list_chitietdonhang.Where(s => s.MaSpNavigation.TenSp.ToUpper().Contains(searchString.ToUpper())).ToList();

                if (list_chitietdonhang.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_chitietdonhang.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "slsp_desc":
                    list_chitietdonhang = list_chitietdonhang.OrderByDescending(s => s.SoLuong).ToList();
                    break;
                case "thanhtien":
                    list_chitietdonhang = list_chitietdonhang.OrderBy(s => s.ThanhTien).ToList();
                    break;
                case "thanhtien_desc":
                    list_chitietdonhang = list_chitietdonhang.OrderByDescending(s => s.ThanhTien).ToList();
                    break;
                default:
                    list_chitietdonhang = list_chitietdonhang.OrderBy(s => s.SoLuong).ToList();
                    break;

            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_chitietdonhang.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbCTDH/Details/5
        public async Task<IActionResult> Details(string madh, string masp)
        {
            if (madh == null || masp == null)
            {
                return BadRequest();
            }

            Sanpham sanpham = null;

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            Chitietdonhang ctdh = null;

            respond = await GetAPI("DonHangUrl").GetAsync($"{ChiTietDonHangpath}/{madh}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctdh = await respond.Content.ReadAsAsync<Chitietdonhang>();

                ctdh.MaSpNavigation = sanpham;
            }

            if (ctdh == null)
            {
                return NotFound();
            }
            return View(ctdh);
        }
    }
}