using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IListGenerator
    {
        IEnumerable<SelectListItem> GetListOfGenders(char? gender);
        IEnumerable<SelectListItem> GetListOfYears(int? year);
    }
}
