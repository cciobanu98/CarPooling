using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling.Web.ViewModels.Settings
{
    public class CarInformationViewModel
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Seats { get; set; }
        public int Id { get; set; }
    }
}
