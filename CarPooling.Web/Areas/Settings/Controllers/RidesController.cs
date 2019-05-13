using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Context;
using CarPooling.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class RidesController : Controller
    {
        public IRideHistoryService _rideHistoryService;
        public readonly IUserService _userService;
        public RidesController(
            IUserService userService,
            IRideHistoryService rideHistoryService)
        {
            _rideHistoryService = rideHistoryService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Offered()
        {
            return View();
        }
        public PartialViewResult OnGetOfferedPartial(int pageIndex = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            var model = _rideHistoryService.GetOfferedRide(id, sort, search, pageIndex, pageSize);
            ViewData["Count"] = _rideHistoryService.GetNumberOfOfferedRides(id, search);
            return new PartialViewResult
            {
                ViewName = "~/Areas/Settings/Views/Rides/_Offered.cshtml",
                ViewData = new ViewDataDictionary<List<OfferedRideDTO>>(ViewData, model)
            };
        }
        public IActionResult Enroled()
        {
            return View();
        }
        public PartialViewResult OnGetEnroledPartial(int pageIndex = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            var model = _rideHistoryService.GetEnroledRide(id, sort, search, pageIndex, pageSize);
            ViewData["Count"] = _rideHistoryService.GetNumberOfEnroledRides(id, search);
            return new PartialViewResult
            {
                ViewName = "~/Areas/Settings/Views/Rides/_Enroled.cshtml",
                ViewData = new ViewDataDictionary<List<EnroledRideDTO>>(ViewData, model)
            };
        }
    }
}