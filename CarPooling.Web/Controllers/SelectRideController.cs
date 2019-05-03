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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CarPooling.Web.Controllers
{
    public class SelectRideController : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Car> _repoCar;
        private readonly IGenericRepository<Location> _repoLocation;
        private readonly IGenericRepository<Ride> _repoRides;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public SelectRideController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<Car> repoCar, IGenericRepository<Location> repoLocation, IGenericRepository<Ride> repoRide, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repoCar = repoCar;
            _repoLocation = repoLocation;
            _repoRides = repoRide;
            _httpContextAccessor = httpContextAccessor;
        }
        private class MinMaxLocation
        {
            public float minLat;
            public float maxLat;
            public float minLong;
            public float maxLong;
        }
        private class Coordinates
        {
            public Coordinates()
            {
                Lat = 0;
                Long = 0;
            }
            public Coordinates(float? Lat, float? Long)
            {
                this.Lat = (float)Lat;
                this.Long = (float)Long;
            }
            public float Lat;
            public float Long;
        }
        [HttpGet]
        private MinMaxLocation GetMinMax(Coordinates c)
        {
            MinMaxLocation temp = new MinMaxLocation();
            temp.minLat = c.Lat -1;
            temp.maxLat = c.Lat +1;
            temp.minLong = c.Long - 1;
            temp.maxLong = c.Long + 1;
            return temp;
        }
        private double deg2rad(float deg)
        {
            return deg * (Math.PI / 180);
        }
        private float GetDistanceInKm(Coordinates c1, Coordinates c2)
        {
            int R = 6371; // Radius of earth in km
            Coordinates dc = new Coordinates();
            dc.Lat = (float)deg2rad(c1.Lat - c2.Lat);
            dc.Long = (float)deg2rad(c1.Long - c2.Long);
            var a = Math.Sin(dc.Lat / 2) * Math.Sin(dc.Lat / 2) +
                    Math.Cos(deg2rad(c1.Lat)) * Math.Cos(deg2rad(c2.Lat)) *
                    Math.Sin(dc.Long / 2) * Math.Sin(dc.Long / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return (float)d;
        }
        private IQueryable<SelectedRidesViewModel> Sort(IQueryable<SelectedRidesViewModel> query, string sort)
        {
            switch (sort)
            {
                case "SortPriceascending":
                    return query.OrderBy(x => x.Price);
                case "SortSourceascending":
                    return query.OrderBy(x => x.DistanceFromSource);
                case "SortDestinationascending":
                    return query.OrderBy(x => x.DistanceFromDestination);
                case "SortDateascending":
                    return query.OrderBy(x => x.TravelStartDateTime);
                case "SortSeatsascending":
                    return query.OrderBy(x => x.Seats);
                case "SortPricedescending":
                    return query.OrderByDescending(x => x.Price);
                case "SortSourcedescending":
                    return query.OrderByDescending(x => x.DistanceFromSource);
                case "SortDestinationdescending":
                    return query.OrderByDescending(x => x.DistanceFromDestination);
                case "SortDatedescending":
                    return query.OrderByDescending(x => x.TravelStartDateTime);
                case "SortSeatsdescending":
                    return query.OrderByDescending(x => x.Seats);
                default:
                    return query.OrderByDescending(x => x.Price);
            }
        }
        public IActionResult SelectRides()
        {
            //ViewData["Count"] = 30;
            return View("~/Views/Home/SelectRide.cshtml");
        }
        public IActionResult SelectedRides(SelectRideViewModel model)
        {
            Coordinates source = new Coordinates();
            Coordinates destination = new Coordinates();
            source.Lat = model.SourceLocationLat;
            source.Long = model.SourceLocationLng;
            destination.Lat = model.DestinationLocationLat;
            destination.Long = model.DestinationLocationLng;
            MinMaxLocation sourceRadius = GetMinMax(source);
            MinMaxLocation destinationRadius = GetMinMax(destination);
            var query = (from r in _context.Rides.Include(x => x.Car.User)
                       .Include(x => x.DestinationLocation)
                       .Include(x => x.SourceLocation)
                         where (r.SourceLocation.Latitude >= sourceRadius.minLat &&
                         r.SourceLocation.Latitude <= sourceRadius.maxLat &&
                         r.SourceLocation.Longitude >= sourceRadius.minLong &&
                         r.SourceLocation.Longitude <= sourceRadius.maxLong &&
                         r.DestinationLocation.Latitude >= destinationRadius.minLat &&
                         r.DestinationLocation.Latitude <= destinationRadius.maxLat &&
                         r.DestinationLocation.Longitude >= destinationRadius.minLong &&
                         r.DestinationLocation.Longitude <= destinationRadius.maxLong &&
                         r.TravelStartDateTime >= Convert.ToDateTime(model.TravelStartDateTime))
                         select new SelectedRidesViewModel
                         {
                             Source = r.SourceLocation.City,
                             Destination = r.DestinationLocation.City,
                             Seats = r.Seats,
                             Price = r.Price,
                             Username = r.Car.User.UserName,
                             DistanceFromSource = GetDistanceInKm(source, new Coordinates(r.SourceLocation.Latitude, r.SourceLocation.Longitude)),
                             DistanceFromDestination = GetDistanceInKm(destination, new Coordinates(r.DestinationLocation.Latitude, r.DestinationLocation.Longitude)),
                             TravelStartDateTime = r.TravelStartDateTime
                         });
            ViewData["Count"] = query.Count();
            ViewData["query"] = query;
            _session.SetString("query", JsonConvert.SerializeObject(query.ToArray()));
            return View("~/Views/Home/SelectedRides.cshtml");
        }
        public PartialViewResult OnGetSelectRidePartial(int pageId = 1, int pageSize = 10, string sort = "default", string search = null)
        {
            var value = _session.GetString("query");
            var query = JsonConvert.DeserializeObject<SelectedRidesViewModel[]>(value).AsQueryable();
            int skip = (pageId - 1) * pageSize;
            query = Sort(query, sort);
            if (search != null && search != "" && search != "null")
            {
                query = query.Where(x => x.Username.Contains(search) || x.Destination.Contains(search) || x.Source.Contains(search));
            }
            ViewData["Count"] = query.Count() ;
            return new PartialViewResult
            {
                ViewName = "~/Views/Home/_SelectRides.cshtml",
                ViewData = new ViewDataDictionary<List<SelectedRidesViewModel>>(ViewData, query.ToList())
            };
        }
    }
}
