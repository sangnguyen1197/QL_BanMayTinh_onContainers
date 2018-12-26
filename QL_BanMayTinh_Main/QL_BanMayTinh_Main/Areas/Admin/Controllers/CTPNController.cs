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
    public class CTPNController : Controller
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

        const string PhieuNhappath = "api/QLPhieuNhap";

        const string ChiTietPhieuNhappath = "api/ChiTietPhieuNhap";


        public async Task<JsonResult> GetInfo(string masp, string mapn)
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Sanpham sp = list_sanpham.SingleOrDefault(m => m.MaSp.Equals(masp));


            var list_chitietphieunhap = new List<Chitietphieunhap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(ChiTietPhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var chitietphieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietphieunhap = JsonConvert.DeserializeObject<IEnumerable<Chitietphieunhap>>(chitietphieunhapJsonString).ToList();
            }

            var ctpn = from s in list_chitietphieunhap where s.MaSp == masp && s.MaPn == mapn select s;

            var giveinfo = new
            {
                tensp = sp.TenSp,
                giabanle = sp.GiaBanLe,
                slt = sp.SoLuongTon,
                checkSP = ctpn.Count()
            };

            return Json(giveinfo);
        }

        // GET: Admin/TbCTPN
        public async Task<IActionResult> Index(string id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            var list_phieunhap = new List<Phieunhap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
            }

            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            ViewBag.TongTienPN = list_phieunhap.Where(s => s.MaPn == id).FirstOrDefault().TongTien;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.SoLuongSortParm = string.IsNullOrEmpty(sortOrder) ? "slsp_desc" : "";
            ViewBag.ThanhTienSortParm = sortOrder == "thanhtien" ? "thanhtien_desc" : "thanhtien";

            if (id == null)
            {
                return BadRequest();
            }

            var list_chitietphieunhap = new List<Chitietphieunhap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(ChiTietPhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var chitietphieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietphieunhap = JsonConvert.DeserializeObject<IEnumerable<Chitietphieunhap>>(chitietphieunhapJsonString).ToList();
            }

            list_chitietphieunhap = list_chitietphieunhap.Where(x => x.MaPn == id).ToList();

            foreach (Chitietphieunhap ctpn in list_chitietphieunhap)
            {
                Sanpham sp = list_sanpham.Find(x => x.MaSp == ctpn.MaSp);

                ctpn.MaSpNavigation = sp;
            }

            ViewBag.maPN = id;

            if (searchString != null) page = 1;
            else searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                list_chitietphieunhap = list_chitietphieunhap.Where(s => s.MaSpNavigation.TenSp.ToUpper().Contains(searchString.ToUpper())).ToList();
                if (list_chitietphieunhap.Count() > 0)
                {
                    TempData["notice"] = "Have result";
                    TempData["dem"] = list_chitietphieunhap.Count();
                }
                else
                {
                    TempData["notice"] = "No result";
                }
            }
            switch (sortOrder)
            {
                case "slsp_desc":
                    list_chitietphieunhap = list_chitietphieunhap.OrderByDescending(s => s.SoLuongNhap).ToList();
                    break;
                case "thanhtien":
                    list_chitietphieunhap = list_chitietphieunhap.OrderBy(s => s.ThanhTien).ToList();
                    break;
                case "thanhtien_desc":
                    list_chitietphieunhap = list_chitietphieunhap.OrderByDescending(s => s.ThanhTien).ToList();
                    break;
                default:
                    list_chitietphieunhap = list_chitietphieunhap.OrderBy(s => s.SoLuongNhap).ToList();
                    break;

            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list_chitietphieunhap.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TbCTPN/Details/5
        public async Task<IActionResult> Details(string mapn, string masp)
        {
            if (mapn == null || masp == null)
            {
                return BadRequest();
            }

            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Chitietphieunhap ctpn = null;

            respond = await GetAPI("PhieuNhapUrl").GetAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctpn = await respond.Content.ReadAsAsync<Chitietphieunhap>();

                Sanpham sp = list_sanpham.Find(x => x.MaSp == ctpn.MaSp);

                ctpn.MaSpNavigation = sp;
            }

            if (ctpn == null)
            {
                return NotFound();
            }
            return View(ctpn);
        }

        // GET: Admin/TbCTPN/Create
        public async Task<IActionResult> Create(string id)
        {
            Chitietphieunhap chitietphieunhap = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{PhieuNhappath}/{id}");

            if (respond.IsSuccessStatusCode)
            {
                chitietphieunhap = await respond.Content.ReadAsAsync<Chitietphieunhap>();
            }

            chitietphieunhap.MaPn = id;

            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Sanpham sp = list_sanpham.Where(s => s.TrangThai == "1").FirstOrDefault();

            TempData["giamacdinh"] = Convert.ToInt32(sp.GiaBanLe);
            TempData["sltmacdinh"] = Convert.ToInt32(sp.SoLuongTon);

            ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp");
            return View(chitietphieunhap);
        }

        // POST: Admin/TbCTPN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPn,MaSp,SoLuongNhap,ThanhTien")] Chitietphieunhap cHITIETPHIEUNHAP)
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Sanpham sp = list_sanpham.Where(s => s.TrangThai == "1").FirstOrDefault();

            TempData["giamacdinh"] = Convert.ToInt32(sp.GiaBanLe);
            TempData["sltmacdinh"] = Convert.ToInt32(sp.SoLuongTon);

            if (ModelState.IsValid)
            {
                respond = await GetAPI("PhieuNhapUrl").PostAsJsonAsync(ChiTietPhieuNhappath, cHITIETPHIEUNHAP);
                respond.EnsureSuccessStatusCode();
                
                try
                {
                    Sanpham up_sltsp = list_sanpham.SingleOrDefault(m => m.MaSp == cHITIETPHIEUNHAP.MaSp);
                    up_sltsp.SoLuongTon = up_sltsp.SoLuongTon + cHITIETPHIEUNHAP.SoLuongNhap;

                    respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{up_sltsp.MaSp}", up_sltsp);

                    respond.EnsureSuccessStatusCode();


                    var list_phieunhap = new List<Phieunhap>();

                    respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

                    if (respond.IsSuccessStatusCode)
                    {
                        var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                        list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
                    }

                    Phieunhap uppn_tongtien = list_phieunhap.SingleOrDefault(m => m.MaPn == cHITIETPHIEUNHAP.MaPn);
                    uppn_tongtien.TongTien = uppn_tongtien.TongTien + cHITIETPHIEUNHAP.ThanhTien;

                    respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{PhieuNhappath}/{uppn_tongtien.MaPn}", uppn_tongtien);

                    respond.EnsureSuccessStatusCode();

                    TempData["notice"] = "Successfully create";
                    TempData["masp"] = cHITIETPHIEUNHAP.MaSp;

                    Sanpham giveten = list_sanpham.Where(s => s.MaSp == cHITIETPHIEUNHAP.MaSp).FirstOrDefault();
                    TempData["tensp"] = giveten.TenSp;
                    ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp");
                    return RedirectToAction("Index", new { id = cHITIETPHIEUNHAP.MaPn });
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                    TempData["masperror"] = cHITIETPHIEUNHAP.MaSp;
                    TempData["tensperror"] = sp.TenSp;
                    TempData["trungmasp"] = "trungmasp";
                    ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp");
                    return View(cHITIETPHIEUNHAP);
                }
            }
            ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp");
            return View(cHITIETPHIEUNHAP);
        }

        // GET: Admin/TbCTPN/Edit/5
        public async Task<IActionResult> Edit(string mapn, string masp)
        {
            var list_phieunhap = new List<Phieunhap>();

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
            }

            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }


            if (mapn == null || masp == null)
            {
                return BadRequest();
            }

            Chitietphieunhap ctpn = null;

            respond = await GetAPI("PhieuNhapUrl").GetAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctpn = await respond.Content.ReadAsAsync<Chitietphieunhap>();

                Sanpham sp = list_sanpham.Find(x => x.MaSp == ctpn.MaSp);

                ctpn.MaSpNavigation = sp;
            }

            int sltpn_cu = (int)ctpn.SoLuongNhap;

            ViewBag.SoLuongSPCu = sltpn_cu;
            ViewBag.TongTien = list_phieunhap.Where(s => s.MaPn == mapn).FirstOrDefault().TongTien;

            ViewBag.TienSP = ctpn.MaSpNavigation.GiaBanLe;

            if (ctpn == null)
            {
                return NotFound();
            }
            ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp", ctpn.MaSp);
            return View(ctpn);
        }

        // POST: Admin/TbCTPN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string mapn, string masp, [Bind("MaPn,MaSp,SoLuongNhap,ThanhTien")] Chitietphieunhap cHITIETPHIEUNHAP)
        {
            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Chitietphieunhap ctpn = null;

            respond = await GetAPI("PhieuNhapUrl").GetAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctpn = await respond.Content.ReadAsAsync<Chitietphieunhap>();
            }

            int slpn_cu = (int)ctpn.SoLuongNhap;
            ViewBag.SoLuongSPCu = slpn_cu;

            var list_chitietphieunhap = new List<Chitietphieunhap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(ChiTietPhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var chitietphieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietphieunhap = JsonConvert.DeserializeObject<IEnumerable<Chitietphieunhap>>(chitietphieunhapJsonString).ToList();
            }

            if (ModelState.IsValid)
            {
                @TempData["notice"] = "Successfully edit";
                @TempData["ctpn"] = cHITIETPHIEUNHAP.MaPn;
                @TempData["masp"] = cHITIETPHIEUNHAP.MaSp;


                respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}", cHITIETPHIEUNHAP);
                respond.EnsureSuccessStatusCode();

                Sanpham sp = list_sanpham.SingleOrDefault(m => m.MaSp == cHITIETPHIEUNHAP.MaSp);
                sp.SoLuongTon = sp.SoLuongTon - slpn_cu + cHITIETPHIEUNHAP.SoLuongNhap;

                respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{sp.MaSp}", sp);
                respond.EnsureSuccessStatusCode();


                var list_phieunhap = new List<Phieunhap>();

                respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

                if (respond.IsSuccessStatusCode)
                {
                    var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                    list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
                }

                Phieunhap pn = list_phieunhap.SingleOrDefault(m => m.MaPn == cHITIETPHIEUNHAP.MaPn);

                
                respond = await GetAPI("PhieuNhapUrl").GetAsync(ChiTietPhieuNhappath);

                if (respond.IsSuccessStatusCode)
                {
                    var chitietphieunhapJsonString = await respond.Content.ReadAsStringAsync();

                    list_chitietphieunhap = JsonConvert.DeserializeObject<IEnumerable<Chitietphieunhap>>(chitietphieunhapJsonString).ToList();
                }

                var entity = list_chitietphieunhap.Where(c => c.MaPn == cHITIETPHIEUNHAP.MaPn && c.MaSp == cHITIETPHIEUNHAP.MaSp).FirstOrDefault();
                
                pn.TongTien = (from s in list_chitietphieunhap
                               where s.MaPn == entity.MaPn
                               select s.ThanhTien).Sum();

                ViewBag.TongTienPN = pn.TongTien;

                respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{PhieuNhappath}/{pn.MaPn}", pn);
                respond.EnsureSuccessStatusCode();

                return RedirectToAction("Index", new { id = cHITIETPHIEUNHAP.MaPn });
            }
            
            
            ViewBag.TienSP = cHITIETPHIEUNHAP.MaSpNavigation.GiaBanLe;
            
            ViewBag.MaSP = new SelectList(list_sanpham.Where(s => s.TrangThai == "1"), "MaSp", "TenSp", cHITIETPHIEUNHAP.MaSp);
            return View(cHITIETPHIEUNHAP);
        }

        // GET: Admin/TbCTPN/Delete/5
        public async Task<IActionResult> Delete(string mapn, string masp)
        {
            if (mapn == null || masp == null)
            {
                return BadRequest();
            }

            var list_sanpham = new List<Sanpham>();

            HttpResponseMessage respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            Chitietphieunhap ctpn = null;

            respond = await GetAPI("PhieuNhapUrl").GetAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctpn = await respond.Content.ReadAsAsync<Chitietphieunhap>();

                Sanpham sp = list_sanpham.Find(x => x.MaSp == ctpn.MaSp);

                ctpn.MaSpNavigation = sp;
            }

            if (ctpn == null)
            {
                return NotFound();
            }
            return View(ctpn);
        }

        // POST: Admin/TbCTPN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string mapn, string masp)
        {
            Chitietphieunhap ctpn = null;

            HttpResponseMessage respond = await GetAPI("PhieuNhapUrl").GetAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

            if (respond.IsSuccessStatusCode)
            {
                ctpn = await respond.Content.ReadAsAsync<Chitietphieunhap>();
            }

            int sl = (int) ctpn.SoLuongNhap;

            @TempData["notice"] = "Successfully delete";
            @TempData["ctpn"] = mapn;
            @TempData["masp"] = masp;

            var list_sanpham = new List<Sanpham>();

            respond = await GetAPI("SanPhamUrl").GetAsync(SanPhampath);

            if (respond.IsSuccessStatusCode)
            {
                var sanphamJsonString = await respond.Content.ReadAsStringAsync();

                list_sanpham = JsonConvert.DeserializeObject<IEnumerable<Sanpham>>(sanphamJsonString).ToList();
            }

            var list_phieunhap = new List<Phieunhap>();

            respond = await GetAPI("PhieuNhapUrl").GetAsync(PhieuNhappath);

            if (respond.IsSuccessStatusCode)
            {
                var phieunhapJsonString = await respond.Content.ReadAsStringAsync();

                list_phieunhap = JsonConvert.DeserializeObject<IEnumerable<Phieunhap>>(phieunhapJsonString).ToList();
            }

            Sanpham sp = list_sanpham.SingleOrDefault(m => m.MaSp == masp);
            sp.SoLuongTon = sp.SoLuongTon - sl;
            if (sp.SoLuongTon >= 0)
            {
                respond = await GetAPI("PhieuNhapUrl").DeleteAsync($"{ChiTietPhieuNhappath}/{mapn}/{masp}");

                respond = await GetAPI("SanPhamUrl").PutAsJsonAsync($"{SanPhampath}/{sp.MaSp}", sp);
                respond.EnsureSuccessStatusCode();

                Phieunhap pn = list_phieunhap.SingleOrDefault(m => m.MaPn == mapn);

                var list_chitietphieunhap = new List<Chitietphieunhap>();

                respond = await GetAPI("PhieuNhapUrl").GetAsync(ChiTietPhieuNhappath);

                if (respond.IsSuccessStatusCode)
                {
                    var chitietphieunhapJsonString = await respond.Content.ReadAsStringAsync();

                    list_chitietphieunhap = JsonConvert.DeserializeObject<IEnumerable<Chitietphieunhap>>(chitietphieunhapJsonString).ToList();
                }

                var infopn = (from s in list_chitietphieunhap
                              where s.MaPn == mapn
                              select s.ThanhTien);
                if (infopn.Count() == 0) pn.TongTien = 0;
                else pn.TongTien = infopn.Sum();
                ViewBag.TongTien = pn.TongTien;


                respond = await GetAPI("PhieuNhapUrl").PutAsJsonAsync($"{PhieuNhappath}/{pn.MaPn}", pn);
                respond.EnsureSuccessStatusCode();
            }
            else
                ViewBag.ErrorSLTon = "errorslt";
            return RedirectToAction("Index", new { id = mapn });
        }
    }
}