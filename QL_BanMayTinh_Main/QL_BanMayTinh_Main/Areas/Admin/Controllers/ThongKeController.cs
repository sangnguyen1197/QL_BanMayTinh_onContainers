using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_BanMayTinh_Main.Areas.Admin.Models;
using QL_BanMayTinh_Main.EF;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
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

        const string DonHangpath = "api/QLDonHang";

        const string ChiTietDonHangpath = "api/ChiTietDonHang";
        

        public async Task<IActionResult> thongkedoanhthu()
        {
            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

            List<string> mangthang = new List<string>();
            
            for (int i = 1; i <= 12; i++)
            {
                mangthang.Add(i.ToString());
            }

            List<decimal> tongtientheothang = new List<decimal>();

            foreach (var a in mangthang)
            {
                var tongtien = list_donhang.Where(x => x.NgayTao.Month == Convert.ToInt32(a)).ToList();

                decimal tongtien_decimal = 0;

                foreach (var s in tongtien)
                {
                    tongtien_decimal = tongtien_decimal + (decimal)s.TongTien;
                }

                tongtientheothang.Add(tongtien_decimal);
            }

            ThongKeModel thongke = new ThongKeModel();

            thongke.mangthang = mangthang;
            thongke.tongtientheothang = tongtientheothang;

            return View(thongke);
        }

        public async Task<IActionResult> thongkesanpham()
        {
            var list_donhang = new List<Donhang>();

            HttpResponseMessage respond = await GetAPI("DonHangUrl").GetAsync(DonHangpath);

            if (respond.IsSuccessStatusCode)
            {
                var donhangJsonString = await respond.Content.ReadAsStringAsync();

                list_donhang = JsonConvert.DeserializeObject<IEnumerable<Donhang>>(donhangJsonString).ToList();
            }

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
                var ctdhJsonString = await respond.Content.ReadAsStringAsync();

                list_chitietdonhang = JsonConvert.DeserializeObject<IEnumerable<Chitietdonhang>>(ctdhJsonString).ToList();
            }


            var result = (from sp in list_sanpham
                          join ctdh in list_chitietdonhang on sp.MaSp equals ctdh.MaSp
                          join dh in list_donhang on ctdh.MaDh equals dh.MaDh

                          where ctdh.MaDh == dh.MaDh && ctdh.MaSp == sp.MaSp
                          && dh.NgayTao.Month == 3

                          group new { sp, ctdh } by sp.TenSp into spbanchay

                          select new SanphambanchayModel()
                          {
                              TenSP = spbanchay.Select(x => x.sp.TenSp).FirstOrDefault(),

                              SoLuongBan = (int) spbanchay.Sum(i => i.ctdh.SoLuong)

                          }).OrderByDescending(s => s.SoLuongBan).Take(3).ToList();


            return View(result);
        }
    }
}