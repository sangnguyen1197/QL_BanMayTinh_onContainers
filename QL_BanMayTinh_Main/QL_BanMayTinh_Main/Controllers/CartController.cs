using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.Common;
using QL_BanMayTinh_Main.EF;
using QL_BanMayTinh_Main.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace QL_BanMayTinh_Main.Controllers
{
    public class CartController : Controller
    {
        private IHostingEnvironment _env;

        public CartController(IHostingEnvironment env)
        {
            _env = env;
        }

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


        public IActionResult IndexCart()
        {
            return View(HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session));
        }

        public async Task<IActionResult> Xacnhan(string madh)
        {
            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

            Donhang donhang = list_donhang.Where(x => x.MaDh == madh).FirstOrDefault();

            donhang.DaThanhToan = 1;


            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }


            var list_chitietdonhang = new List<Chitietdonhang>();

            respond = await GetAPI("DonHangUrl").GetAsync(ChiTietDonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var chtietdonhangJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietdonhang = JsonConvert.DeserializeObject<IEnumerable<Chitietdonhang>>(chtietdonhangJsonString).ToList();
            }

            list_chitietdonhang = list_chitietdonhang.Where(x => x.MaDh == madh).ToList();

            foreach (var ctdh in list_chitietdonhang)
            {
                Sanpham sp = list_sanpham.Where(x => x.MaSp == ctdh.MaSp).FirstOrDefault();

                int soluongtonhientai = (int)sp.SoLuongTon;
                int soluongmua = (int)ctdh.SoLuong;
                int soluongconlai = soluongtonhientai - soluongmua;

                sp.SoLuongTon = soluongconlai;

                respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{sp.MaSp}", sp);

                respond.EnsureSuccessStatusCode();
            }

            respond = await GetAPI("DonHangUrl").PutAsJsonAsync($"{DonHangpath}/{donhang.MaDh}", donhang);
            respond.EnsureSuccessStatusCode();

            return View();
        }

        public async Task<string> getMaDH()
        {
            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

            var countRow = list_donhang.Count();

            int getCount = countRow + 1;

            string newMaDH = "DH";

            if (getCount < 10) newMaDH += "00" + getCount.ToString();

            else if (getCount < 100) newMaDH += "0" + getCount.ToString();

            return newMaDH;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session);

            string user = HttpContext.Session.GetString(CommonConstants.User_Session);

            if(user != null && user != "")
            {
                if(cart != null)
                {
                    return View(cart);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Payment(string shipName, string mobile, string address, string email)
        {
            string user = HttpContext.Session.GetString(CommonConstants.User_Session);

            if (user != null && user != "")
            {
                var cart = HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session);

                decimal tongtien = 0;
                foreach (var item in cart)
                {
                    decimal tien = item.sanpham.GiaBanLe * item.soluong;
                    tongtien = tongtien + tien;
                }

                var order = new Donhang();
                order.MaDh = await getMaDH();
                order.NgayTao = DateTime.Now;

                order.TaiKhoan = user;

                order.ShipMobile = mobile;
                order.ShipAddress = address;
                order.Shipname = shipName;
                order.ShipEmail = email;
                order.Status = 1;
                order.DaThanhToan = 0;
                order.TongTien = tongtien;

                decimal tongtien1 = (decimal)order.TongTien;
                try
                {
                    var id = order.MaDh;

                    HttpResponseMessage respond = await GetAPI("DonHangUrl").PostAsJsonAsync(DonHangpath, order);
                    respond.EnsureSuccessStatusCode();


                    foreach (var item in cart)
                    {
                        var orderdetail = new Chitietdonhang();

                        orderdetail.MaSp = item.sanpham.MaSp;

                        orderdetail.MaDh = id;
                        orderdetail.ThanhTien = item.sanpham.GiaBanLe * item.soluong;
                        orderdetail.SoLuong = item.soluong;

                        respond = await GetAPI("DonHangUrl").PostAsJsonAsync(ChiTietDonHangpath, orderdetail);
                        respond.EnsureSuccessStatusCode();
                    }

                    string webRoot = _env.WebRootPath.ToString();

                    string file = webRoot + "\\template\\neworder.html";

                    var baseurl = Request.Scheme + "://" + Request.Host + Request.PathBase;

                    string content = System.IO.File.ReadAllText(file);

                    string link = baseurl + "/Cart/Xacnhan?madh=" + order.MaDh + "";

                    content = content.Replace("{{OrderID}}", order.MaDh);
                    content = content.Replace("{{CustomerName}}", shipName);
                    content = content.Replace("{{Phone}}", mobile);
                    content = content.Replace("{{Email}}", email);
                    content = content.Replace("{{Address}}", address);
                    content = content.Replace("{{Total}}", tongtien1.ToString("#,##0"));
                    content = content.Replace("{{link}}", link);

                    var toEmail = order.ShipEmail;
                    toEmail = email;

                    new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Electro Store", content);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //throw;
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
            return Redirect("/Cart/Success");
        }

        public async Task<bool> Checksoluongton(string cartModel)
        {
            var jsoncart = JsonConvert.DeserializeObject<List<CartItemModel>>(cartModel);
            
            foreach (var item in jsoncart)
            {
                Sanpham sanpham = null;

                HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{item.sanpham.MaSp}");

                if (respond.IsSuccessStatusCode)
                {
                    sanpham = await respond.Content.ReadAsAsync<Sanpham>();
                }

                int soluongton = (int)sanpham.SoLuongTon;

                if (item.soluong > soluongton)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<JsonResult> Update(string cartModel)
        {
            var jsoncart = JsonConvert.DeserializeObject<List<CartItemModel>>(cartModel);

            var sessionCart = HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session);

            if (await Checksoluongton(cartModel) == true)
            {
                foreach (var item in sessionCart)
                {
                    var jsonItem = jsoncart.SingleOrDefault(x => x.sanpham.MaSp == item.sanpham.MaSp);

                    if (jsonItem != null)
                    {
                        item.soluong = jsonItem.soluong;
                    }
                }

                HttpContext.Session.SetObject(CommonConstants.Cart_Session, sessionCart);

                return Json(new
                {
                    status = true
                });
            }

            return Json(new
            {
                status = false
            });
        }

        public JsonResult DeleteAll()
        {
            HttpContext.Session.SetObject<List<CartItemModel>>(CommonConstants.Cart_Session, null);

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string id)
        {
            var sessionCart = HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session);

            sessionCart.RemoveAll(x => x.sanpham.MaSp == id);

            HttpContext.Session.SetObject(CommonConstants.Cart_Session, sessionCart);

            return Json(new
            {
                status = true
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] string masp)
        {
            var Cart = HttpContext.Session.GetObject<List<CartItemModel>>(CommonConstants.Cart_Session);

            List<CartItemModel> ListCart = new List<CartItemModel>();

            if (Cart != null)
            {
                ListCart = (List<CartItemModel>)Cart;
            }

            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            if (ListCart.Any(a => a.sanpham.MaSp == masp))
            {
                ListCart.FirstOrDefault(a => a.sanpham.MaSp == masp).soluong++;
            }
            else
            {
                ListCart.Add(new CartItemModel() { sanpham = list_sanpham.Single(x => x.MaSp == masp), soluong = 1 });
            }

            HttpContext.Session.SetObject(CommonConstants.Cart_Session, ListCart);

            return Json(new
            {
                status = true
            });
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}