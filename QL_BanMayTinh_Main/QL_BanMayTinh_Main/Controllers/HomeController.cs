using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.Common;
using QL_BanMayTinh_Main.EF;
using QL_BanMayTinh_Main.Models;

namespace QL_BanMayTinh_Main.Controllers
{
    public class HomeController : Controller
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

        const string KhachHangpath = "api/QLKhachHang";

        const string SanPhampath = "api/QLSanPham";

        const string ThuongHieupath = "api/QLThuongHieu";


        FilterModel model = new FilterModel();

        public HomeController()
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

        public async Task<IActionResult> Index()
        {
            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            var list_sanpham = new List<Sanpham>();

            if (respond.IsSuccessStatusCode)
            {
                respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }
            

            var mymodel = new HomeViewModel();

            mymodel.ViewSanPham = list_sanpham.Where(x => x.TrangThai == "1").ToList();

            mymodel.ViewThuongHieu = list_thuonghieu;

            mymodel.myfilter = model;

            return View(mymodel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public async Task<IActionResult> Product(string mathuonghieu)
        {
            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            var list_sanpham = new List<Sanpham>();

            if (respond.IsSuccessStatusCode)
            {
                respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            var brand = list_thuonghieu.Where(x => x.MaThuongHieu == mathuonghieu).SingleOrDefault();
            ViewBag.Name = brand.TenThuongHieu;

            var searchmodel = new SearchModel();

            searchmodel.SearchResult = list_sanpham.Where(x => x.MaThuongHieu == mathuonghieu).ToList();

            searchmodel.filter = model;

            return View(searchmodel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Taikhoan taiKhoan = null;

                HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync($"{KhachHangpath}/{model.username}");

                if (respond.IsSuccessStatusCode)
                {
                    // Gán dữ liệu API đọc được
                    taiKhoan = await respond.Content.ReadAsAsync<Taikhoan>();

                    if (SHA1_Encryptor.HashSHA1(model.password) == taiKhoan.MatKhau)
                    {
                        HttpContext.Session.SetString(CommonConstants.User_Session, taiKhoan.TaiKhoan1);

                        if (taiKhoan.TaiKhoan1 == "admin")
                        {
                            return RedirectToAction("IndexAdmin", "AdminHome", new { area = "Admin" });
                        }

                        return Redirect("/");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CommonConstants.User_Session);

            HttpContext.Session.SetObject<List<CartItemModel>>(CommonConstants.Cart_Session, null);

            return Redirect("/");
        }

        public IActionResult Authorize()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
