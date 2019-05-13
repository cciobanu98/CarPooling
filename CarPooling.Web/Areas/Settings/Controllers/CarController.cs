using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using System.Collections.Generic;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Area("Settings")]
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
        public IActionResult Index()
        {
            //Try to change to model
            //To do pagination or to restrict to 5 cars
            List<CarInformationDTO> cars = _userService.GetAllCarOfUser(HttpContext.User);
            ViewData["List"] = cars;
            return View();
        }
        [HttpPost]
        public IActionResult Add(CarInformationDTO carModel)
        {
            if (ModelState.IsValid)
            {
                string userId = _userService.GetUserIdByClaims(HttpContext.User);
                _carService.AddCar(userId, carModel);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Car Add error");
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(CarInformationDTO carModel)
        {
            if (ModelState.IsValid)
            {
                _carService.EditCar(carModel);
                return RedirectToAction();
            }

            ModelState.AddModelError("", "Car Edit error");
            return RedirectToAction();
        }
    }
}
