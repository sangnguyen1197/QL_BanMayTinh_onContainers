using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using X.PagedList;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
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

        const string DonHangpath = "api/QLDonHang";


        // GET: Admin/TbDonHang
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaDHSortParm = string.IsNullOrEmpty(sortOrder) ? "madh" : "";
            ViewBag.TaiKhoanSortParm = sortOrder == "taikhoan" ? "taikhoan_desc" : "taikhoan";
            ViewBag.NgayTaoDHSortParm = sortOrder == "ngaytaodh" ? "ngaytaodh_desc" : "ngaytaodh";
            ViewBag.TongTienSortParm = sortOrder == "tongtien" ? "tongtien_desc" : "tongtien";

            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

            list_donhang = list_donhang.Where(x => x.Status == 1).OrderByDescending(s => s.NgayTao).ToList();

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_donhang = list_donhang.Where(s => s.Shipname.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_donhang.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_donhang.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "madh":
                    list_donhang = list_donhang.OrderBy(s => s.MaDh).ToList();
                    break;
                case "taikhoan":
                    list_donhang = list_donhang.OrderBy(s => s.TaiKhoanNavigation.HoTen).ToList();
                    break;
                case "taikhoan_desc":
                    list_donhang = list_donhang.OrderByDescending(s => s.TaiKhoanNavigation.HoTen).ToList();
                    break;
                case "ngaytaodh":
                    list_donhang = list_donhang.OrderBy(s => s.NgayTao).ToList();
                    break;
                case "ngaytaodh_desc":
                    list_donhang = list_donhang.OrderByDescending(s => s.NgayTao).ToList();
                    break;
                case "tongtien":
                    list_donhang = list_donhang.OrderBy(s => s.TongTien).ToList();
                    break;
                case "tongtien_desc":
                    list_donhang = list_donhang.OrderByDescending(s => s.TongTien).ToList();
                    break;
                default:
                    list_donhang = list_donhang.OrderByDescending(s => s.MaDh).ToList();
                    break;

            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_donhang.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbDonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Donhang donhang = null;

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync($"{DonHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                donhang = await respond.Content.ReadAsAsync<Donhang>();
            }

            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }
        
        // GET: Admin/TbDonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Donhang donhang = null;

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync($"{DonHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                donhang = await respond.Content.ReadAsAsync<Donhang>();
            }

            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Admin/TbDonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDh,NgayTao,TaiKhoan,Shipname,ShipMobile,ShipAddress,ShipEmail,TongTien,DaThanhToan,Status")] Donhang dONHANG)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage respond = await GetAPI("DonHangUrl").PutAsJsonAsync($"{DonHangpath}/{id}", dONHANG);
                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully edit";
                TempData["madh"] = dONHANG.MaDh;
                return RedirectToAction("Index");
            }

            return View(dONHANG);
        }

        // GET: Admin/TbDonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Donhang donhang = null;

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync($"{DonHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                donhang = await respond.Content.ReadAsAsync<Donhang>();
            }

            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Admin/TbDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Donhang donhang = null;

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync($"{DonHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                donhang = await respond.Content.ReadAsAsync<Donhang>();
            }

            donhang.Status = 0;

            respond = await GetAPI("DonHangUrl").PutAsJsonAsync($"{DonHangpath}/{id}", donhang);

            respond.EnsureSuccessStatusCode();

            TempData["notice"] = "Successfully delete";
            TempData["madh"] = donhang.MaDh;

            return RedirectToAction("Index");
        }
    }
}
