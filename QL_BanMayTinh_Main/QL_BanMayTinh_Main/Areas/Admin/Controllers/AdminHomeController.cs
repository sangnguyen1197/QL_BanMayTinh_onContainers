using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_BanMayTinh_Main.Common;

namespace QL_BanMayTinh_Main.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult IndexAdmin()
        {
            string user = HttpContext.Session.GetString(CommonConstants.User_Session);

            if (user != "admin")
            {
                return RedirectToAction("Authorize", "Home", new { area = "" });
            }
            else
            {
                return View();
            }
        }
    }
}