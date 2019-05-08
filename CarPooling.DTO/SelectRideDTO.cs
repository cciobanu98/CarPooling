using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class SelectRideDTO
    { 
        public string TravelStartDateTime { get; set; }
        public float SourceLocationLat { get; set; }
        public float SourceLocationLng { get; set; }
        public float DestinationLocationLat { get; set; }
        public float DestinationLocationLng { get; set; }
    }
}
