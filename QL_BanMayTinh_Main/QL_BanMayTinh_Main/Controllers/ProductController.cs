using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using QL_BanMayTinh_Main.Models;

namespace QL_BanMayTinh_Main.Controllers
{
    public class ProductController : Controller
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


        FilterModel model = new FilterModel();

        public ProductController()
        {
            GenerateCheckBox();
        }

        public void GenerateCheckBox()
        {
            List<PriceModel> p = new List<PriceModel>
            {
                new PriceModel() { PriceID = "cbPrice-1", PriceName = "Dưới 10 triệu VNĐ", PriceValue = " (GiaBanLe < 10000000) ", IsChecked = false },
                new PriceModel() { PriceID = "cbPrice-2", PriceName = "Từ 10 triệu - 15 triệu VNĐ", PriceValue = " (GiaBanLe between 10000000 and 15000000) ", IsChecked = false },
                new PriceModel() { PriceID = "cbPrice-3", PriceName = "Từ 15 triệu - 20 triệu VNĐ", PriceValue = " (GiaBanLe between 15000000 and 20000000) ", IsChecked = false },
                new PriceModel() { PriceID = "cbPrice-4", PriceName = "Trên 20 triệu VNĐ", PriceValue = " (GiaBanLe > 20000000) ", IsChecked = false }
            };

            List<CategoryModel> c = new List<CategoryModel>
            {
                new CategoryModel() { CategoryID = "cbCategory-1", CategoryName = "ASUS", CategoryValue = " MaThuongHieu = 'ASUS' ", IsChecked = false },
                new CategoryModel() { CategoryID = "cbCategory-2", CategoryName = "DELL", CategoryValue = " MaThuongHieu = 'DELL' ", IsChecked = false },
                new CategoryModel() { CategoryID = "cbCategory-3", CategoryName = "ACER", CategoryValue = " MaThuongHieu = 'ACER' ", IsChecked = false },
                new CategoryModel() { CategoryID = "cbCategory-4", CategoryName = "HP", CategoryValue = " MaThuongHieu = 'HP' ", IsChecked = false }
            };

            model = new FilterModel
            {
                PriceList = p,
                CategoryList = c
            };
        }

        public async Task<IActionResult> Details(string id)
        {
            Sanpham sanpham = null;

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            return View(sanpham);
        }

        public async Task<IActionResult> Search(string keyword)
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }


            var result = list_sanpham.Where(x => x.TenSp.Contains(keyword));

            int totalRecord = result.Count();

            if (totalRecord == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + totalRecord + " sản phẩm";
            }

            ViewBag.Keyword = "Kết quả tìm kiếm theo từ khóa: ' " + keyword + " '";

            var searchmodel = new SearchModel();
            searchmodel.SearchResult = result.ToList();
            searchmodel.filter = model;

            return View(searchmodel);
        }

        public async Task<JsonResult> ListName(string q)
        {
            if (q.Count() >= 2)
            {
                var list_sanpham = new List<Sanpham>();

                HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

                if (respond.IsSuccessStatusCode)
                {
                    var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                    list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
                }

                var data = list_sanpham.Where(x => x.TenSp.Contains(q) && q != "").Select(x => x.TenSp).ToList();

                return Json(new
                {
                    data,
                    status = true
                });
            }
            else
            {
                return null;
            }
        }

        public async Task<IActionResult> Category(string categoryName)
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            var result = list_sanpham.ToList();

            if (categoryName != "all")
            {
                result = list_sanpham.Where(x => x.MaThuongHieu == categoryName).OrderByDescending(x => x.TenSp).ToList();
            }

            int totalRecord = result.Count();

            if (totalRecord == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
            }
            if (categoryName == "all")
            {
                ViewBag.Keyword = "Tất cả sản phẩm";
            }
            else
            {
                ViewBag.Keyword = categoryName;
            }

            var categorymodel = new SearchModel();
            categorymodel.SearchResult = result;
            categorymodel.filter = model;

            return View(categorymodel);
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Filter(string[] gia, string[] loai)
        {
            int totalRecord = 0;
            string noi = "and";
            string trong = "";
            string sql = "select * from SANPHAM where TrangThai = '1' ";

            List<string[]> mang = new List<string[]>();

            if (gia.Count() != 0)
            {
                mang.Add(gia);
                foreach (var a in model.PriceList)
                {
                    foreach (var s in gia)
                    {
                        if (a.PriceValue.Equals(s) == true)
                        {
                            a.IsChecked = true;
                        }
                    }
                }
            }

            if (loai.Count() != 0)
            {
                mang.Add(loai);
                foreach (var a in model.CategoryList)
                {
                    foreach (var s in loai)
                    {
                        if (a.CategoryValue.Equals(s) == true)
                        {
                            a.IsChecked = true;
                        }
                    }
                }
            }

            foreach (string[] a in mang)
            {
                sql = sql + noi;
                for (int i = 0; i < a.Count(); i++)
                {
                    sql = sql + trong + a[i];
                    trong = "or";
                }
                trong = "";
            }

            var result = new SanPham_DAL().Filter(ref totalRecord, ref sql);

            if (totalRecord == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
            }
            else
            {
                if (sql == "select * from SANPHAM where TrangThai = '1' ")
                {
                    ViewBag.ThongBao = "Tất cả sản phẩm";
                }
                else
                {
                    ViewBag.ThongBao = "Ðã tìm thấy " + totalRecord + " sản phẩm";
                }
            }

            var postmodel = new SearchModel();
            postmodel.SearchResult = result;
            postmodel.filter = model;

            return View(postmodel);
        }*/
    }
}