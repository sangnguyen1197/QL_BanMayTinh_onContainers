using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.EF;
using X.PagedList;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhieuNhapController : Controller
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

        const string PhieuNhappath = "api/QLPhieuNhap";


        // GET: Admin/TbPhieuNhap
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaPNSortParm = string.IsNullOrEmpty(sortOrder) ? "mapn" : "";
            ViewBag.NgayNhapSortParm = sortOrder == "ngaynhap" ? "ngaynhap_desc" : "ngaynhap";
            ViewBag.TongTienSortParm = sortOrder == "tongtien" ? "tongtien_desc" : "tongtien";

            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            var list_phieunhap = new List<Phieunhap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
            }

            foreach (Phieunhap pn in list_phieunhap)
            {
                Nhacungcap ncc = list_nhacungcap.Find(x => x.MaNcc == pn.MaNcc);

                pn.MaNccNavigation = ncc;
            }

            list_phieunhap = list_phieunhap.Where(x => x.Flag == 1).OrderByDescending(s => s.NgayNhap).ToList();

            if (searchString != null)
                page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_phieunhap = list_phieunhap.Where(s => s.MaNccNavigation.TenNcc.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_phieunhap.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_phieunhap.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "mapn":
                    list_phieunhap = list_phieunhap.OrderBy(s => s.MaPn).ToList();
                    break;
                case "ngaynhap":
                    list_phieunhap = list_phieunhap.OrderBy(s => s.NgayNhap).ToList();
                    break;
                case "ngaynhap_desc":
                    list_phieunhap = list_phieunhap.OrderByDescending(s => s.NgayNhap).ToList();
                    break;
                case "tongtien":
                    list_phieunhap = list_phieunhap.OrderBy(s => s.TongTien).ToList();
                    break;
                case "tongtien_desc":
                    list_phieunhap = list_phieunhap.OrderByDescending(s => s.TongTien).ToList();
                    break;
                default:
                    list_phieunhap = list_phieunhap.OrderByDescending(s => s.MaPn).ToList();
                    break;

            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_phieunhap.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbPhieuNhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Phieunhap phieunhap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{PhieuNhappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                phieunhap = await respond.Content.ReadAsAsync<Phieunhap>();
            }

            if (phieunhap == null)
            {
                return NotFound();
            }
            return View(phieunhap);
        }

        // GET: Admin/TbPhieuNhap/Create
        public async Task<string> getMaPN()
        {
            var list_phieunhap = new List<Phieunhap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
            }

            var countRow = list_phieunhap.Count();
            int getCount = countRow + 1;
            string newMaPN = "PN";
            if (getCount < 10) newMaPN += "00" + getCount.ToString();
            else if (getCount < 100) newMaPN += "0" + getCount.ToString();
            return newMaPN;
        }

        public async Task<IActionResult> Create()
        {
            Phieunhap pn = new Phieunhap();
            pn.MaPn = await getMaPN();
            pn.NgayNhap = DateTime.Now;

            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            ViewBag.MaNCC = new SelectList(list_nhacungcap.Where(x => x.Flag == 1), "MaNcc", "TenNcc");
            return View(pn);
        }

        // POST: Admin/TbPhieuNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPn,NgayNhap,MaNcc,TongTien")] Phieunhap pHIEUNHAP)
        {
            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            if (ModelState.IsValid)
            {
                pHIEUNHAP.Flag = 1;
                pHIEUNHAP.TongTien = 0;

                respond = await GetAPI("PhieuNhapUrl").PostAsJsonAsync(PhieuNhappath, pHIEUNHAP);
                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully create";
                TempData["phieunhap"] = pHIEUNHAP.MaPn;
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(list_nhacungcap.Where(x => x.Flag == 1), "MaNcc", "TenNcc", pHIEUNHAP.MaNcc);
            return View(pHIEUNHAP);
        }

        // GET: Admin/TbPhieuNhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Phieunhap phieunhap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{PhieuNhappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                phieunhap = await respond.Content.ReadAsAsync<Phieunhap>();
            }

            if (phieunhap == null)
            {
                return NotFound();
            }

            var list_nhacungcap = new List<Nhacungcap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            ViewBag.MaNCC = new SelectList(list_nhacungcap.Where(x => x.Flag == 1), "MaNcc", "TenNcc", phieunhap.MaNcc);
            return View(phieunhap);
        }

        // POST: Admin/TbPhieuNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPn,NgayNhap,MaNcc,TongTien")] Phieunhap pHIEUNHAP)
        {
            var list_nhacungcap = new List<Nhacungcap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(NhaCungCappath);

            if (respond.IsSuccessStatusCode)
            {
                var nhacungcapJsonString = await respond.Content.ReadAsStringAsync();

                list_nhacungcap = JsonConvert.DeserializeObject<IEnumerable<Nhacungcap>>(nhacungcapJsonString).ToList();
            }

            if (ModelState.IsValid)
            {
                pHIEUNHAP.Flag = 1;

                respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{PhieuNhappath}/{id}", pHIEUNHAP);

                respond.EnsureSuccessStatusCode();

                TempData["notice"] = "Successfully edit";
                TempData["phieunhap"] = pHIEUNHAP.MaPn;
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(list_nhacungcap.Where(x => x.Flag == 1), "MaNcc", "TenNcc", pHIEUNHAP.MaNcc);
            return View(pHIEUNHAP);
        }

        // GET: Admin/TbPhieuNhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Phieunhap phieunhap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{PhieuNhappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                phieunhap = await respond.Content.ReadAsAsync<Phieunhap>();

                Nhacungcap nhacungcap = null;

                respond = await GetAPI("PhieuNhapUrl").GetAsync($"{NhaCungCappath}/{phieunhap.MaNcc}");

                if (respond.IsSuccessStatusCode)
                {
                    nhacungcap = await respond.Content.ReadAsAsync<Nhacungcap>();

                    phieunhap.MaNccNavigation = nhacungcap;
                }
            }

            if (phieunhap == null)
            {
                return NotFound();
            }
            return View(phieunhap);
        }

        // POST: Admin/TbPhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Phieunhap phieunhap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{PhieuNhappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                phieunhap = await respond.Content.ReadAsAsync<Phieunhap>();
            }

            phieunhap.Flag = 0;

            respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{PhieuNhappath}/{id}", phieunhap);

            respond.EnsureSuccessStatusCode();

            TempData["notice"] = "Successfully delete";
            TempData["phieunhap"] = phieunhap.MaPn;
            return RedirectToAction("Index");
        }
    }
}