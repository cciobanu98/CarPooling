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
        public SelectRideController(IHttpContextAccessor httpContextAccessor, ISelectRideService selectRideService)
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
            List<SelectedRidesDTO> query = _selectRidesService.GetSelectedRides(model);
            ViewData["Count"] = query.Count();
            ViewData["query"] = query;
            _session.SetString("query", JsonConvert.SerializeObject(query.ToArray()));
            return View();
        }
        public PartialViewResult OnGetSelectRidePartial(int pageId = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            string value = _session.GetString("query");
            IQueryable<SelectedRidesDTO> query = JsonConvert.DeserializeObject<SelectedRidesDTO[]>(value).AsQueryable();
            int skip = (pageId - 1) * pageSize;
            query = _selectRidesService.SortAndFilterRides(query, search, sort);
            ViewData["Count"] = query.Count();
            var model = _selectRidesService.PaginateRides(query, skip, pageSize);
            return new PartialViewResult
            {
                ViewName = "~/Views/SelectRide/_SelectRides.cshtml",
                ViewData = new ViewDataDictionary<List<SelectedRidesDTO>>(ViewData, model)
            };
        }
    }
}
