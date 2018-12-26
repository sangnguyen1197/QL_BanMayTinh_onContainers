using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using X.PagedList;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
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

        const string ThuongHieupath = "api/QLThuongHieu";


        public static string GetNewPathForDupes(string path, ref string fn)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            int counter = 1;
            string newFullPath = path;
            string new_file_name = filename + extension;
            while (System.IO.File.Exists(newFullPath))
            {
                string newFilename = string.Format("{0}({1}){2}", filename, counter, extension);
                new_file_name = newFilename;
                newFullPath = Path.Combine(directory, newFilename);
                counter++;
            };
            fn = new_file_name;
            return newFullPath;
        }

        public async Task<string> getMaSP()
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            var countRow = list_sanpham.Count();

            int getCount = countRow + 1;

            string newMaSP = "SP";

            if (getCount < 10) newMaSP += "00" + getCount.ToString();
            else if (getCount < 100) newMaSP += "0" + getCount.ToString();
            return newMaSP;
        }

        // GET: Admin/TbSanPham
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TenSPSortParm = sortOrder == "tensp" ? "tensp_desc" : "tensp";
            ViewBag.SLTonSortParm = sortOrder == "spton" ? "slton_desc" : "spton";
            ViewBag.GiaBanSortParm = sortOrder == "giaban" ? "giaban_desc" : "giaban";

            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }
            
            list_sanpham = list_sanpham.Where(x => x.TrangThai == "1").OrderByDescending(s => s.MaSp).ToList();

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_sanpham = list_sanpham.Where(s => s.TenSp.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_sanpham.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_sanpham.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "tensp":
                    list_sanpham = list_sanpham.OrderBy(s => s.TenSp).ToList();
                    break;
                case "tensp_desc":
                    list_sanpham = list_sanpham.OrderByDescending(s => s.TenSp).ToList();
                    break;
                case "slton":
                    list_sanpham = list_sanpham.OrderBy(s => s.SoLuongTon).ToList();
                    break;
                case "slton_desc":
                    list_sanpham = list_sanpham.OrderByDescending(s => s.SoLuongTon).ToList();
                    break;
                case "giaban":
                    list_sanpham = list_sanpham.OrderBy(s => s.GiaBanLe).ToList();
                    break;
                case "giaban_desc":
                    list_sanpham = list_sanpham.OrderByDescending(s => s.GiaBanLe).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_sanpham.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbSanPham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Sanpham sanpham = null;

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            // Explicit Load Foreign Key Value
            //var fk = db.Sanpham.Single(a => a.MaSp == id);
            //db.Entry(fk).Reference(s => s.MaThuongHieuNavigation).Load();

            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Admin/TbSanPham/Create
        public async Task<IActionResult> Create()
        {
            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            Sanpham sp = new Sanpham();

            sp.MaSp = await getMaSP();

            ViewBag.MaThuongHieu = new SelectList(list_thuonghieu, "MaThuongHieu", "MaThuongHieu");

            return View(sp);
        }

        // POST: Admin/TbSanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,MaThuongHieu,SoLuongTon,GiaBanLe,XuatSu,Motakithuat,Hinhanh,Hinhanhindex,TrangThai")] Sanpham sANPHAM, IFormCollection fc)
        {
            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            if (ModelState.IsValid)
            {
                sANPHAM.SoLuongTon = 0;
                sANPHAM.TrangThai = "1";

                respond = await GetAPI("SanPhamUrl").PostAsJsonAsync(SanPhampath, sANPHAM);
                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully create";
                TempData["tensanpham"] = sANPHAM.TenSp;

                return RedirectToAction("Index");
            }

            ViewBag.MaThuongHieu = new SelectList(list_thuonghieu, "MaThuongHieu", "MaThuongHieu", sANPHAM.MaThuongHieu);
            return View(sANPHAM);
        }

        // GET: Admin/TbSanPham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            Sanpham sanpham = null;

            respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            if (sanpham == null)
            {
                return NotFound();
            }

            ViewBag.MaThuongHieu = new SelectList(list_thuonghieu, "MaThuongHieu", "MaThuongHieu", sanpham.MaThuongHieu);
            return View(sanpham);
        }

        // POST: Admin/TbSanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSp,TenSp,MaThuongHieu,SoLuongTon,GiaBanLe,XuatSu,Motakithuat,Hinhanh,Hinhanhindex,TrangThai")] Sanpham sANPHAM, IFormCollection fc)
        {
            var list_thuonghieu = new List<Thuonghieu>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(ThuongHieupath);

            if (respond.IsSuccessStatusCode)
            {
                var thuonghieuJsonString = await respond.Content.ReadAsStringAsync();

                list_thuonghieu = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(thuonghieuJsonString).ToList();
            }

            if (ModelState.IsValid)
            {
                TempData["notice"] = "Successfully edit";
                TempData["tensanpham"] = sANPHAM.TenSp;

                respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{id}", sANPHAM);

                respond.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }

            ViewBag.MaThuongHieu = new SelectList(list_thuonghieu, "MaThuongHieu", "MaThuongHieu", sANPHAM.MaThuongHieu);

            return View(sANPHAM);
        }

        // GET: Admin/TbSanPham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Sanpham sanpham = null;

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/TbSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Sanpham sanpham = null;

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync($"{SanPhampath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                // Gán dữ liệu API đọc được
                sanpham = await respond.Content.ReadAsAsync<Sanpham>();
            }

            sanpham.TrangThai = "0";

            respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{id}", sanpham);

            respond.EnsureSuccessStatusCode();
            
            TempData["notice"] = "Successfully delete";
            TempData["tensanpham"] = sanpham.TenSp;
            
            return RedirectToAction("Index");
        }
    }
}