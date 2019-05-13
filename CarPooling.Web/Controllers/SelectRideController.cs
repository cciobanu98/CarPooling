using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;

namespace CarPooling.Web.Controllers
{
    public class SelectRideController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISelectRideService _selectRidesService;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public SelectRideController(IHttpContextAccessor httpContextAccessor,
            ISelectRideService selectRideService)
        {
            _httpContextAccessor = httpContextAccessor;
            _selectRidesService = selectRideService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectedRides(SelectRideDTO model)
        {
            _session.SetString("select", JsonConvert.SerializeObject(model));
            return View();
        }
        public PartialViewResult OnGetSelectedRidesPartial(int pageIndex = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            string value = _session.GetString("select");
            var select = JsonConvert.DeserializeObject<SelectRideDTO>(value);
            List<SelectedRidesWithDistanceDTO> query = _selectRidesService.GetSelectedRides(select, sort, search, pageIndex, pageSize);
            ViewData["Count"] = _selectRidesService.GetNumberOfSelectedRides(select, search);
            return new PartialViewResult
            {
                ViewName = "~/Views/SelectRide/_SelectedRides.cshtml",
                ViewData = new ViewDataDictionary<List<SelectedRidesWithDistanceDTO>>(ViewData, query)
            };
        }
    }
}
