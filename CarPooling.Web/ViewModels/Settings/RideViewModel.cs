using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling.Web.ViewModels.Settings
{
    public class RideViewModel
    {
        public int CarId { get; set; }
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public float SourceLocationLat { get; set; }
        public float SourceLocationLng { get; set; }
        public float DestinationLocationLat { get; set; }
        public float DestinationLocationLng { get; set; }
        public string TravelStartDateTime { get; set; }
        public int Seats { get; set; }
    }
}
