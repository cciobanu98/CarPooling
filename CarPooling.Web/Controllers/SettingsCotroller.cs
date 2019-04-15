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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPooling.Web.Controllers
{
    [Route("Settings")]
    [Authorize(Roles = "admin, user")]
    public class SettingsCotroller : Controller
    {
        private readonly CarPoolingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _repo;
        public SettingsCotroller(CarPoolingContext context, UserManager<User> userManager, IMapper mapper, IGenericRepository<User> repo)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _repo = repo;
        }
        private IEnumerable<SelectListItem> SetListOfYears(int? year)
        {
            List<SelectListItem> years = new List<SelectListItem>();
            for (int i = 1900; i <= DateTime.Now.Year - 18; i++)
            {
                if (i == year && year != DateTime.Now.Year)
                    years.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = true });
                else
                    years.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return years;
        }
        private IEnumerable<SelectListItem> SetListOfGenders(char? gender)
        {
            List<SelectListItem> genders = new List<SelectListItem>();
            genders.Add(new SelectListItem { Text = "Male", Value = "M" });
            genders.Add(new SelectListItem { Text = "Female", Value = "F" });
            var selected = genders.SingleOrDefault(y => y.Value[0] == gender);
            if (selected != null)
                selected.Selected = true;
            return genders;
        }
        // GET: /<controller>/
        [HttpGet]
        [Route("GeneralInformation")]
        public IActionResult GeneralInformation()
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var user = _repo.GetById(id);
            GeneralInformationViewModel model = _mapper.Map<GeneralInformationViewModel>(user);
            model.Years = SetListOfYears(DateTime.Now.Year);
            model.Genders = SetListOfGenders(user.Gender);
            return View("~/Views/Settings/General.cshtml", model);
        }
        [HttpPost]
        [Route("GeneralInformation")]
        public IActionResult GeneralInformation(GeneralInformationViewModel model)
        {
            var id = _userManager.GetUserId(HttpContext.User);
            User user = _repo.GetById(id);
            if (user == null)
                return NotFound();
            Mapper.Map<GeneralInformationViewModel, User>(model, user);
            _repo.Update(user);
            _repo.Save();
            model.Years = SetListOfYears(DateTime.Now.Year);
            model.Genders = SetListOfGenders(user.Gender);
            return View("~/Views/Settings/General.cshtml", model);
        }
    }
}
