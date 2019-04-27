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
        public SelectRideController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<Car> repoCar, IGenericRepository<Location> repoLocation, IGenericRepository<Ride> repoRide)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repoCar = repoCar;
            _repoLocation = repoLocation;
            _repoRides = repoRide;
        }
        [HttpGet]
        public IActionResult SelectRide()
        {
            var query = from r in _context.Rides.Include(x => x.Car.User)
                        .Include(x => x.DestinationLocation)
                        .Include(x => x.SourceLocation)
                        select new SelectRideViewModel
                        {
                            Destination = r.DestinationLocation.City + ',' + r.DestinationLocation.Country,
                            Source = r.SourceLocation.City + ',' + r.SourceLocation.Country,
                            Price = r.Price,
                            StartDatetime = r.TravelStartDateTime.ToString(),
                            UserName = r.Car.User.UserName,
                            Seats = 4
                        };
            ViewData["List"] = query;
            return View("~/Views/Home/rides.cshtml");
        }
    }
}
