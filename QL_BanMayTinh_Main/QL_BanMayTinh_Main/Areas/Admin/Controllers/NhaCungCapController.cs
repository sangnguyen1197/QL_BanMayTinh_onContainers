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
    public class NhaCungCapController : Controller
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

        const string NhaCungCappath = "api/QLNhaCungCap";


        // GET: Admin/TbNhaCungCap
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaNCCSortParm = string.IsNullOrEmpty(sortOrder) ? "MaNCC_desc" : "";
            ViewBag.TenNCCSortParm = sortOrder == "tenncc" ? "tenncc_desc" : "tenncc";

            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            list_nhacungcap = list_nhacungcap.Where(x => x.Flag == 1).ToList();

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_nhacungcap = list_nhacungcap.Where(s => s.TenNcc.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_nhacungcap.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_nhacungcap.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }

            switch (sortOrder)
            {
                case "MaNCC_desc":
                    list_nhacungcap = list_nhacungcap.OrderByDescending(s => s.MaNcc).ToList();
                    break;
                case "tenncc":
                    list_nhacungcap = list_nhacungcap.OrderBy(s => s.TenNcc).ToList();
                    break;
                case "tenncc_desc":
                    list_nhacungcap = list_nhacungcap.OrderByDescending(s => s.TenNcc).ToList();
                    break;
                default:
                    list_nhacungcap = list_nhacungcap.OrderBy(s => s.MaNcc).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_nhacungcap.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbNhaCungCap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Nhacungcap nhacungcap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{NhaCungCappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                nhacungcap = await respond.Content.ReadAsAsync<Nhacungcap>();
            }

            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        public async Task<string> getMaNCC()
        {
            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            var countRow = list_nhacungcap.Count();
            int getCount = countRow + 1;
            string newMaNCC = "NCC";
            if (getCount < 10) newMaNCC += "00" + getCount.ToString();
            else if (getCount < 100) newMaNCC += "0" + getCount.ToString();
            return newMaNCC;
        }

        // GET: Admin/TbNhaCungCap/Create
        public async Task<IActionResult> Create()
        {
            Nhacungcap ncc = new Nhacungcap();

            ncc.MaNcc = await getMaNCC();

            return View(ncc);
        }

        // POST: Admin/TbNhaCungCap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNcc,TenNcc,DiaChi,Sdt")] Nhacungcap nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                nHACUNGCAP.Flag = 1;

                HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").PostAsJsonAsync(NhaCungCappath, nHACUNGCAP);
                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully create";
                TempData["tenncc"] = nHACUNGCAP.TenNcc;
                return RedirectToAction("Index");
            }

            return View(nHACUNGCAP);
        }

        // GET: Admin/TbNhaCungCap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Nhacungcap nhacungcap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{NhaCungCappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                nhacungcap = await respond.Content.ReadAsAsync<Nhacungcap>();
            }

            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Admin/TbNhaCungCap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaNcc,TenNcc,DiaChi,Sdt")] Nhacungcap nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                nHACUNGCAP.Flag = 1;

                HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{NhaCungCappath}/{nHACUNGCAP.MaNcc}", nHACUNGCAP);
                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully edit";
                TempData["tenncc"] = nHACUNGCAP.TenNcc;
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: Admin/TbNhaCungCap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Nhacungcap nhacungcap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{NhaCungCappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                nhacungcap = await respond.Content.ReadAsAsync<Nhacungcap>();
            }

            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Admin/TbNhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Nhacungcap nhacungcap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{NhaCungCappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                nhacungcap = await respond.Content.ReadAsAsync<Nhacungcap>();
            }

            nhacungcap.Flag = 0;

            respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{NhaCungCappath}/{nhacungcap.MaNcc}", nhacungcap);
            respond.EnsureSuccessStatusCode();

            TempData["notice"] = "Successfully delete";
            TempData["tenncc"] = nhacungcap.TenNcc;
            return RedirectToAction("Index");
        }
    }
}