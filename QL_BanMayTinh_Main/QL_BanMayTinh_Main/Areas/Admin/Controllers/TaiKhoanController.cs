using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using X.PagedList;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoanController : Controller
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


        // GET: Admin/TbTaiKhoan
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";

            var list_taikhoan = new List<Taikhoan>();

            HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync(KhachHangpath);

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                var taiKhoanJsonString = await respond.Content.ReadAsStringAsync();

                var deserialized = JsonConvert.DeserializeObject<IEnumerable<Taikhoan>>(taiKhoanJsonString);

                list_taikhoan = deserialized.ToList();
            }

            list_taikhoan = list_taikhoan.Where(x => x.Flag == 1).ToList();

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_taikhoan = list_taikhoan.Where(s => s.HoTen.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_taikhoan.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_taikhoan.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "name_desc":
                    list_taikhoan = list_taikhoan.OrderByDescending(s => s.HoTen).ToList();
                    break;
                case "Date":
                    list_taikhoan = list_taikhoan.OrderBy(s => s.NgaySinh).ToList();
                    break;
                case "date_desc":
                    list_taikhoan = list_taikhoan.OrderByDescending(s => s.NgaySinh).ToList();
                    break;
                default:
                    list_taikhoan = list_taikhoan.OrderBy(s => s.HoTen).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_taikhoan.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbTaiKhoan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Taikhoan tAIKHOAN = null;

            HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync($"{KhachHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                tAIKHOAN = await respond.Content.ReadAsAsync<Taikhoan>();
            }

            if (tAIKHOAN == null)
            {
                return NotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/TbTaiKhoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TbTaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TaiKhoan1,MatKhau,Email,Quyen,HoTen,GioiTinh,NgaySinh,Sdt,DiaChi,Flag")] Taikhoan tAIKHOAN)
        {
            /*if (ModelState.IsValid)
            {
                db.Taikhoan.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction(nameof(IndexAsync));
            }*/

            return View(tAIKHOAN);
        }

        // GET: Admin/TbTaiKhoan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Taikhoan tAIKHOAN = null;

            HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync($"{KhachHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                tAIKHOAN = await respond.Content.ReadAsAsync<Taikhoan>();
            }

            if (tAIKHOAN == null)
            {
                return NotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/TbTaiKhoan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TaiKhoan1,MatKhau,Email,Quyen,HoTen,GioiTinh,NgaySinh,Sdt,DiaChi,Flag")] Taikhoan tAIKHOAN)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["notice"] = "Successfully edit";
                    TempData["taikhoan"] = tAIKHOAN.TaiKhoan1;

                    HttpResponseMessage respond = await GetAPI("KhachHangUrl").PutAsJsonAsync($"{KhachHangpath}/{id}", tAIKHOAN);

                    respond.EnsureSuccessStatusCode();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Lưu lại không thành công. Vui lòng thử lại");
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/TbTaiKhoan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Taikhoan tAIKHOAN = null;

            HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync($"{KhachHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                tAIKHOAN = await respond.Content.ReadAsAsync<Taikhoan>();
            }

            if (tAIKHOAN == null)
            {
                return NotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/TbTaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Taikhoan tAIKHOAN = null;

            HttpResponseMessage respond = await GetAPI("KhachHangUrl").GetAsync($"{KhachHangpath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                tAIKHOAN = await respond.Content.ReadAsAsync<Taikhoan>();
            }

            tAIKHOAN.Flag = 0;

            respond = await GetAPI("KhachHangUrl").PutAsJsonAsync($"{KhachHangpath}/{id}", tAIKHOAN);

            respond.EnsureSuccessStatusCode();

            TempData["notice"] = "Successfully delete";
            TempData["taikhoan"] = tAIKHOAN.TaiKhoan1;
            return RedirectToAction("Index");
        }
    }
}