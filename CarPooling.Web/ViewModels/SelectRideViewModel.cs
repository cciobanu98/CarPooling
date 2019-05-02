using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling.Web.ViewModels
{
    public class SelectRideViewModel
    {
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string TravelStartDateTime { get; set; }
        public float SourceLocationLat { get; set; }
        public float SourceLocationLng { get; set; }
        public float DestinationLocationLat { get; set; }
        public float DestinationLocationLng { get; set; }
    }
}
