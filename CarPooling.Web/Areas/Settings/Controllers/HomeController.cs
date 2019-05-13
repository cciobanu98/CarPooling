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
            return View();
        }
    }
}
