using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.Common;
using QL_BanMayTinh_Main.EF;
using QL_BanMayTinh_Main.Models;

namespace QL_BanMayTinh_Main.Controllers
{
    public class UserController : Controller
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


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var list_taiKhoan = new List<Taikhoan>();

                HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync(KhachHangpath);

                if (respond.IsSuccessStatusCode)
                {
                    var taiKhoanJsonString = await respond.Content.ReadAsStringAsync();

                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<Taikhoan>>(taiKhoanJsonString);

                    list_taiKhoan = deserialized.ToList();
                    
                    bool AccountExists = list_taiKhoan.Count(x => x.TaiKhoan1 == model.TaiKhoan1) > 0;

                    bool EmailExists = list_taiKhoan.Count(x => x.Email == model.Email) > 0;

                    int flag = 1;

                    if(AccountExists == true)
                    {
                        ModelState.AddModelError("error", "Tên đăng nhập đã tồn tại");
                        flag = 0;
                    }
                    if(EmailExists == true)
                    {
                        ModelState.AddModelError("error", "Địa chỉ Email đã tồn tại");
                        flag = 0;
                    }

                    if(flag != 0)
                    {
                        var tk = new Taikhoan();
                        tk.TaiKhoan1 = model.TaiKhoan1;
                        tk.MatKhau = SHA1_Encryptor.HashSHA1(model.MatKhau);
                        tk.Email = model.Email;
                        tk.Quyen = "2";
                        tk.HoTen = model.HoTen;
                        tk.GioiTinh = model.GioiTinh.ToString("G");
                        tk.NgaySinh = Convert.ToDateTime(model.NgaySinh.ToShortDateString());
                        tk.Sdt = model.Sdt;
                        tk.DiaChi = model.DiaChi;
                        tk.Flag = 1;


                        respond = await GetAPI("KhachHangUrl").PostAsJsonAsync(KhachHangpath, tk);

                        if (respond.IsSuccessStatusCode)
                        {
                            ViewBag.Success = "Đăng ký thành công!";
                            TempData["alertMessage"] = "Đăng ký thành công!";

                            return Redirect("/Home/Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng ký không thành công");
                        }
                    }
                }
            }
            return View(model);
        }
    }
}