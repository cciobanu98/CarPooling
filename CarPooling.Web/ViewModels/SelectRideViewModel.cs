using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling.Web.ViewModels
{
    public class SelectRideViewModel
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string StartDatetime { get; set; }
        public int Price { get; set; }
        public int Seats { get; set; }
        public string UserName { get; set; }
    }
}
