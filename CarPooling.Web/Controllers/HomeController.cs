using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.Context;
using CarPooling.Domain;
using Microsoft.AspNetCore.Identity;
using CarPooling.Web.ViewModels;
using CarPooling.DataAcces.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarPooling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public HomeController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var query = (from r in _context.Rides.Include(x => x.Car.User)
                        .Include(x => x.DestinationLocation)
                        .Include(x => x.SourceLocation)
                         orderby r.CreatedDateTime ascending
                         select new LastRideViewModel
                         {
                             Id = r.Id,
                             Destination = r.DestinationLocation.City,
                             Source = r.SourceLocation.City,
                             Seats = r.Seats,
                             User = r.Car.User.UserName,
                             StartDateTime = r.TravelStartDateTime
                         }).Take(5).ToList();
            ViewData["List"] = query;
            return View();
        }
        [Route("Home/AllRides")]
        [HttpGet]
        public IActionResult AllRides()
        {
            ViewData["Count"] = _context.Rides.Count();
            return View();
        }
        public IActionResult Contact()
        {
            return View("~/Views/Home/Contact.cshtml");
        }
        public PartialViewResult OnGetRidesPartial(int pageId = 1, int size = 10)
        {
            int skip = (pageId - 1) * size;
            var query = (from r in _context.Rides.Include(x => x.Car.User)
            .Include(x => x.DestinationLocation)
            .Include(x => x.SourceLocation)
                         orderby r.CreatedDateTime ascending
                         select new LastRideViewModel
                         {
                             Id = r.Id,
                             Destination = r.DestinationLocation.City,
                             Source = r.SourceLocation.City,
                             Seats = r.Seats,
                             User = r.Car.User.UserName,
                             StartDateTime = r.TravelStartDateTime
                         }).Skip(skip).Take(size);
            return new PartialViewResult
            {
                ViewName = "_Rides",
                ViewData = new ViewDataDictionary<List<LastRideViewModel>>(ViewData, query.ToList())
            };
        }
    }
}
