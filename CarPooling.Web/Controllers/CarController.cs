using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using System.Collections.Generic;

namespace CarPooling.Web.Controllers
{
    [Route("Settings/Car")]
    [Authorize(Roles = "admin, user")]
    public class CarController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        public CarController(IUserService userService, ICarService carService)
        {
            _userService = userService;
            _carService = carService;
        }
        [HttpGet]
        public IActionResult CarInformation()
        {
            //Try to change to model
            //To do pagination or to restrict to 5 cars
            List<CarInformationDTO> cars = _userService.GetAllCarOfUser(HttpContext.User);
            ViewData["List"] = cars;
            return View("~/Views/Settings/Car/Car.cshtml");
        }
        [HttpPost]
        public IActionResult CarInformation(CarInformationDTO carModel)
        {
            if (ModelState.IsValid)
            {
                string userId = _userService.GetUserIdByClaims(HttpContext.User);
                _carService.AddCar(userId, carModel);
                return RedirectToAction("CarInformation");
            }
            ModelState.AddModelError("", "Car Add error");
            return RedirectToAction("CarInformation");
        }
        [Route("Delete/{id?}")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _carService.DeleteCarById(id ?? default(int));
            return RedirectToAction("CarInformation");
        }
        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(CarInformationDTO carModel)
        {
            if (ModelState.IsValid)
            {
                _carService.EditCar(carModel);
                return RedirectToAction("CarInformation");
            }

            ModelState.AddModelError("", "Car Edit error");
            return RedirectToAction("CarInformation");
        }
    }
}
