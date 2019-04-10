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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPooling.Web.Controllers
{
    [Route("Settings")]
    [Authorize(Roles = "admin, user")]
    public class SettingsCotroller : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        public SettingsCotroller(CarPoolingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        [HttpGet]
        [Route("GeneralInformation")]
        public IActionResult GeneralInformation()
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var user = _context.Users.FirstOrDefault(m => m.Id == id);
            var model = new GeneralInformationViewModel { Firstname = user.FirstName, Lastname = user.LastName, Username = user.UserName };
            return View("~/Views/Settings/General.cshtml", model);
        }
        [HttpPost]
        [Route("GeneralInformation")]
        public IActionResult GeneralInformation(GeneralInformationViewModel model)
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var user = _context.Users.SingleOrDefault(m => m.Id == id);
            if (user == null)
                return NotFound();
            user.UserName = model.Username;
            user.FirstName = model.Firstname;
            user.LastName = model.Lastname;
            _context.Update(user);
            _context.SaveChanges();
            return View("~/Views/Settings/General.cshtml", model);
        }

    }
}
