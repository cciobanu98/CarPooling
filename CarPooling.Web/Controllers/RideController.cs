using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.Context;
using CarPooling.Domain;
using Microsoft.AspNetCore.Identity;
using CarPooling.Web.ViewModels.Settings;
using CarPooling.DataAcces.Repository;
using AutoMapper;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarPooling.Web.Controllers
{
    public class RideController : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Car> _repoCar;
        private readonly IGenericRepository<Location> _repoLocation;
        private readonly IGenericRepository<Ride> _repoRides;
        public RideController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<Car> repoCar, IGenericRepository<Location> repoLocation, IGenericRepository<Ride> repoRide)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repoCar = repoCar;
            _repoLocation = repoLocation;
            _repoRides = repoRide;
        }
        [HttpGet]
        public IActionResult AddRide()
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var Cars = _repoCar.GetAll();
            var query = from c in Cars
                        where c.UserId == id
                        select new CarInformationViewModel
                        {
                            Color = c.Color,
                            Model = c.Model,
                            Seats = c.Seats,
                            Number = c.Number,
                            Id = c.Id
                        };
            ViewData["List"] = query;
            return View("~/Views/Home/AddRide.cshtml");
        }

        [HttpPost]
        public IActionResult AddRide(RideViewModel rideModel)
        {
            Ride ride = new Ride();
            Location source = new Location();
            Location destination = new Location();
            var sourceInfo = rideModel.SourceLocation.Split(",");
            var destinationInfo = rideModel.DestinationLocation.Split(",");
            source.Latitude = rideModel.SourceLocationLat;
            source.Longitude = rideModel.SourceLocationLng;
            source.Street = sourceInfo[0];
            source.City = sourceInfo[1];
            if (sourceInfo.Length != 2)
                source.Country = sourceInfo[2];
            destination.Latitude = rideModel.DestinationLocationLat;
            destination.Longitude = rideModel.DestinationLocationLng;
            destination.Street = destinationInfo[0];
            destination.City = destinationInfo[1];
            if (destinationInfo.Length != 2)
                destination.Country = destinationInfo[2];
            ride.CreatedDateTime = DateTime.Now;
            ride.SourceLocation = source;
            ride.DestinationLocation = destination;
            ride.TravelStartDateTime = Convert.ToDateTime(rideModel.TravelStartDateTime);
            ride.Price = 20;
            ride.Car = _repoCar.GetById(rideModel.CarId);
            _repoRides.Insert(ride);
            _repoRides.Save();
            return RedirectToAction("AddRide");
        }
    }
}
