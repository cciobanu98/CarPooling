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
    [Route("Car")]
    [Authorize(Roles = "admin, user")]
    public class CarController : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Car> _repoCar;
        public CarController(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<Car> repoCar)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repoCar = repoCar;
        }
        [HttpGet]
        [Route("CarInformation")]
        public IActionResult CarInformation()
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
            return View("~/Views/Settings/Car.cshtml");
        }
        [HttpPost]
        [Route("CarInformation")]
        public IActionResult CarInformation(CarInformationViewModel carModel)
        {
            var id = _userManager.GetUserId(HttpContext.User);
            Car car = _mapper.Map<Car>(carModel);
            car.User = _userManager.GetUserAsync(HttpContext.User).Result;
            _repoCar.Insert(car);
            _repoCar.Save();
            return RedirectToAction("CarInformation");
            //return View("~/Views/Settings/Car.cshtml");
        }
        [Route("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _repoCar.Delete(id);
            _repoCar.Save();
            return RedirectToAction("CarInformation");
        }
        [HttpPost]
        public IActionResult Edit(CarInformationViewModel carModel)
        {
            Car car = _repoCar.GetById(carModel.Id);
            Mapper.Map(carModel, car);
            _repoCar.Update(car);
            _repoCar.Save();
            return RedirectToAction("CarINformation");
        }
    }
}
