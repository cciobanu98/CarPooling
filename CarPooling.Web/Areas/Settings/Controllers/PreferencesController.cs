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
    public class PreferencesController : Controller
    {
        private readonly IPreferencesService _preferencesService;
        private readonly IUserService _userService;
        public PreferencesController(IPreferencesService preferencesService, IUserService userService)
        {
            _preferencesService = preferencesService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var id = _userService.GetUserIdByClaims(HttpContext.User);
            if (id == null)
                return NotFound();
            var model = _preferencesService.GetPreferences(id);
            return View(model);
        }
        public IActionResult SavePreferences(PreferencesDTO model)
        {
            if (ModelState.IsValid)
            {
                var id = _userService.GetUserIdByClaims(HttpContext.User);
                _preferencesService.Edit(model, id);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Preferences Edit error");
            return RedirectToAction("Index");
        }
    }
}