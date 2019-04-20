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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarPooling.Web.Controllers
{
    public class RideController : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Car> _repoCar;
        public RideController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<Car> repoCar)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repoCar = repoCar;
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
            return View("~/Views/Home/add-ride.cshtml");
        }
        [HttpPost]
        public IActionResult AddRide(RideViewModel ride)
        {
            Console.WriteLine("Test");
            return View("~/Views/Home/add-ride.cshtml");
        }
    }
}
