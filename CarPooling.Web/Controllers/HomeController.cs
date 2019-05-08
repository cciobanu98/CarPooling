using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using CarPooling.DTO;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Domain;
namespace CarPooling.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ISelectRideService _selectRideService;
        private readonly IRideService _rideService;
        public HomeController(ISelectRideService selectRideService, IRideService rideService)
        {
            _selectRideService = selectRideService;
            _rideService = rideService;
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
            ViewData["Count"] = _selectRideService.GetAllRides().Count;
            return View();
        }
        public PartialViewResult OnGetRidesPartial(int pageId = 1, int size = 10, string sortmode = null, string search = null)
        {
            int skip = (pageId - 1) * size;
            var rides = _selectRideService.GetAllRides().AsQueryable();
            rides = _selectRideService.SortAndFilterRides(rides.AsQueryable(), search, sortmode);
            ViewData["Count"] = rides.Count();
            var model = _selectRideService.PaginateRides(rides, skip, size);
            return new PartialViewResult
            {
                ViewName = "_Rides",
                ViewData = new ViewDataDictionary<List<SelectedRidesDTO>>(ViewData, model)
            };
        }
        public PartialViewResult OnGetMoreInformation(int id)
        {
            var model = _rideService.GetRideInformation(id);
            return new PartialViewResult
            {
                ViewName = "_MoreInformation",
                ViewData = new ViewDataDictionary<RideInformationDTO>(ViewData, model)
            };
        }
    }
}
