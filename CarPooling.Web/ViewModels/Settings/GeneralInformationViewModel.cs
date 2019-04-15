using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace CarPooling.Web.ViewModels.Settings
{
    public class GeneralInformationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? YearofBirth { get; set; }
        public char? Gender { get; set; }
        [IgnoreMap]
        public IEnumerable<SelectListItem> Years { get; set; }
        [IgnoreMap]
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}
