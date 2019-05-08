using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarPooling.BussinesLogic.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarPooling.BussinesLogic.Services
{
    public class ListGenerator : IListGenerator
    {
        public IEnumerable<SelectListItem> GetListOfYears(int? year)
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
        public  IEnumerable<SelectListItem> GetListOfGenders(char? gender)
        {
            List<SelectListItem> genders = new List<SelectListItem>();
            genders.Add(new SelectListItem { Text = "Male", Value = "M" });
            genders.Add(new SelectListItem { Text = "Female", Value = "F" });
            var selected = genders.SingleOrDefault(y => y.Value[0] == gender);
            if (selected != null)
                selected.Selected = true;
            return genders;
        }
    }
}
