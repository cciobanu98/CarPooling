using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class PreferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}