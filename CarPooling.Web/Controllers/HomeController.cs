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
        private readonly IUserService _userService;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public HomeController(ISelectRideService selectRideService,
            IRideService rideService,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _selectRideService = selectRideService;
            _rideService = rideService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
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
        public PartialViewResult OnGetAllRidesPartial(int pageIndex = 1, int size = 10, string sort = null, string search = null)
        {
            var rides = _selectRideService.GetAllRides(sort, search, pageIndex, size);
            ViewData["Count"] = _selectRideService.GetNumberOfRides(search);
            return new PartialViewResult
            {
                ViewName = "_AllRides",
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
        public PartialViewResult OnGetProfilePartial(string userName)
        {
            var id = _userService.GetUserIdByUserName(userName);
            var model = _userService.GetUserProfile(id);
            return new PartialViewResult
            {
                ViewName = "_Profile",
                ViewData = new ViewDataDictionary<ProfileDTO>(ViewData, model)
            };

        }
    }
}
