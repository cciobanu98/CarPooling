using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.Web.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class GeneralController : Controller
    {
        private readonly IListGenerator _listGeneratorService;
        private readonly IUserService _userService;
        public GeneralController(IListGenerator listGeneratorService, IUserService userService)
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