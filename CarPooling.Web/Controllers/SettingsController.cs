using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPooling.DTO;
using CarPooling.BussinesLogic.Interfaces;

namespace CarPooling.Web.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class SettingsController : Controller
    {
        private readonly IListGenerator _listGeneratorService;
        private readonly IUserService _userService;
        public SettingsController(IListGenerator listGeneratorService, IUserService userService)
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
