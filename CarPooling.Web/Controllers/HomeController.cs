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
        private IQueryable<LastRideViewModel> Sort(IQueryable<LastRideViewModel> query, string sort)
        {
            switch (sort)
            {
                case "SortDateAllascending":
                    return query.OrderBy(x => x.StartDateTime);
                case "SortSeatsAllascending":
                    return query.OrderBy(x => x.Seats);
                case "SortSeatsAlldescending":
                    return query.OrderByDescending(x => x.Seats);
                default:
                    return query.OrderByDescending(x => x.StartDateTime);
            }
        }
        public PartialViewResult OnGetRidesPartial(int pageId = 1, int size = 10, string sortmode = null, string search = null)
        {
            int skip = (pageId - 1) * size;
            var query = (from r in _context.Rides.Include(x => x.Car.User)
            .Include(x => x.DestinationLocation)
            .Include(x => x.SourceLocation)
                         select new LastRideViewModel
                         {
                             Id = r.Id,
                             Destination = r.DestinationLocation.City,
                             Source = r.SourceLocation.City,
                             Seats = r.Seats,
                             User = r.Car.User.UserName,
                             StartDateTime = r.TravelStartDateTime
                         });
            query = Sort(query, sortmode);
            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                query = query.Where(x => x.User.Contains(search) || x.Destination.Contains(search) || x.Source.Contains(search));
            }
            ViewData["Count"] = query.Count();
            query = query.Skip(skip).Take(size);
            return new PartialViewResult
            {
                ViewName = "_Rides",
                ViewData = new ViewDataDictionary<List<LastRideViewModel>>(ViewData, query.ToList())
            };
        }
        public PartialViewResult OnGetMoreInformation(int id)
        {
            var model = new MoreInformationViewModel();
            var ride = _context.Rides.Include(x => x.SourceLocation)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Car)
                .Include(x => x.Car.User)
                .Include(x => x.Car.User.Preferences)
                .SingleOrDefault(x => x.Id == id);
            model.FirstName = ride.Car.User.FirstName;
            model.LastName = ride.Car.User.LastName;
            model.Phone = ride.Car.User.PhoneNumber;
            model.Email = ride.Car.User.Email;
            //model.Description = ride.Car.User.Preferences.Description;
            model.CarColor = ride.Car.Color;
            model.CarNumber = ride.Car.Number;
            model.CarModel = ride.Car.Model;
            model.SourceAddress = ride.SourceLocation.Street;
            model.SourceCity = ride.SourceLocation.City;
            model.SourceState = ride.SourceLocation.Country;
            model.DestinationAddress = ride.DestinationLocation.Street;
            model.DestinationCity = ride.DestinationLocation.City;
            model.DestinationState = ride.DestinationLocation.Country;
            model.Price = ride.Price;
            return new PartialViewResult
            {
                ViewName = "_MoreInformation",
                ViewData = new ViewDataDictionary<MoreInformationViewModel>(ViewData, model)
            };
        }
    }
}
