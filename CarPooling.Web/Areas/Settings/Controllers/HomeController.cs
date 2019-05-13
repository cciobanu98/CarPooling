using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.DTO;
using CarPooling.BussinesLogic.Interfaces;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Area("Settings")]
    public class HomeController : Controller
    {
        private readonly IListGenerator _listGeneratorService;
        private readonly IUserService _userService;
        public HomeController(IListGenerator listGeneratorService, IUserService userService)
        {
            _listGeneratorService = listGeneratorService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            GeneralInformationDTO model = _userService.GetInformationAboutUser(HttpContext.User);
            ViewData["years"] = _listGeneratorService.GetListOfYears(DateTime.Now.Year);
            ViewData["genders"] = _listGeneratorService.GetListOfGenders(model.Gender);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(GeneralInformationDTO model)
        {
            if (ModelState.IsValid)
            {
                _userService.EditInformationAboutUser(HttpContext.User, model);
            }
            ModelState.AddModelError("", "SettingsEditError");
            return RedirectToAction("Index");
        }
    }
}
