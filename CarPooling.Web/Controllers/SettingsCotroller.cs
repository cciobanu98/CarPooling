using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPooling.Web.Controllers
{
    [Route("Settings")]
    [Authorize(Roles = "admin, user")]
    public class SettingsCotroller : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("~/Views/Settings/General.cshtml");
        }
    }
}
