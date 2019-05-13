using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using CarPooling.DTO;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CarPooling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISelectRideService _selectRideService;
        private readonly IRideService _rideService;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public HomeController(ISelectRideService selectRideService,
            IRideService rideService,
            IHttpContextAccessor httpContextAccessor)
        {
            _selectRideService = selectRideService;
            _rideService = rideService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var lastrides = _selectRideService.GetAllRides().OrderByDescending(x => x.CreatedDateTime).Take(5);
            ViewData["List"] = lastrides.ToList();
            return View();
        }
        [Route("Home/AllRides")]
        [HttpGet]
        public IActionResult AllRides()
        {
            return View();
        }
        public PartialViewResult OnGetRidesPartial(int pageIndex = 1, int size = 10, string sort = null, string search = null)
        {
            var rides = _selectRideService.GetAllRides(sort, search, pageIndex, size);
            ViewData["Count"] = _selectRideService.GetNumberOfRides(search);
            return new PartialViewResult
            {
                ViewName = "_Rides",
                ViewData = new ViewDataDictionary<List<SelectedRidesDTO>>(ViewData, rides)
            };
        }
        public PartialViewResult OnGetMoreInformation(int id)
        {
            var model = _rideService.GetRideInformation(id);
            var temp = _session.GetString("select");
            if (temp != null)
            {
                SelectRideDTO select = JsonConvert.DeserializeObject<SelectRideDTO>(temp);
                _rideService.AddInformationAboutSelect(model, select);
                ViewData["select"] = select;
            }
            else
                ViewData["select"] = null;
            return new PartialViewResult
            {
                ViewName = "_MoreInformation",
                ViewData = new ViewDataDictionary<RideInformationDTO>(ViewData, model)
            };
        }
    }
}
