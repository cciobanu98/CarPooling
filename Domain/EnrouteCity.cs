using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class EnrouteCity
    {
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
