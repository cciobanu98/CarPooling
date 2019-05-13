using System.Collections.Generic;
using System.Linq;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class RatingsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRatingService _ratingService;
        public RatingsController(IUserService userService, 
           IRatingService ratingService)
        {
            _userService = userService;
            _ratingService = ratingService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Left()
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            ViewData["Count"] = _ratingService.GetLeftRatings(id).Count;
            return View();
        }
        public PartialViewResult OnGetLeftPartial(int pageIndex = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            var model = _ratingService.GetLeftRatings(id, sort, search, pageIndex, pageSize);
            ViewData["Count"] = _ratingService.GetNumberOfLeftRatings(id, search);
            return new PartialViewResult
            {
                ViewName = "~/Areas/Settings/Views/Ratings/_Left.cshtml",
                ViewData = new ViewDataDictionary<List<RatingLeftDTO>>(ViewData, model)
            };
        }
        public IActionResult Received()
        {
            return View();
        }
        public PartialViewResult OnGetReceivedPartial(int pageIndex = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            var model = _ratingService.GetReceivedRatings(id, sort, search, pageIndex, pageSize);
            ViewData["Count"] = _ratingService.GetNumberOfReceivedRatings(id, search);
            return new PartialViewResult
            {
                ViewName = "~/Areas/Settings/Views/Ratings/_Received.cshtml",
                ViewData = new ViewDataDictionary<List<RatingReceivedDTO>>(ViewData, model)
            };
        }
        [HttpPost]
        public IActionResult AddRating(RatingDTO model)
        {
            if (ModelState.IsValid)
            {
                string userId = _userService.GetUserIdByClaims(HttpContext.User);
                _ratingService.AddRatingToRide(model, userId);
                return RedirectToAction("Enroled", "Rides");
            }
            ModelState.AddModelError("", "Rating Add Error");
            return RedirectToAction("Enroled", "Rides");
        }

        public PartialViewResult OnGetRatePartial()
        {
            return new PartialViewResult
            {
                ViewName = "~/Areas/Settings/Views/Ratings/_Rate.cshtml",
            };
        }
    }
}