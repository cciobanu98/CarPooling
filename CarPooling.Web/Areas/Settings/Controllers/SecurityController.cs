using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}