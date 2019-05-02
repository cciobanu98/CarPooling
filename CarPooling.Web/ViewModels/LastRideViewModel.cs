using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling.Web.ViewModels
{
    public class LastRideViewModel
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string User { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Seats { get; set; }
    }
}
