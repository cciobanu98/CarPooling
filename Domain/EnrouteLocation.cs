using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class EnrouteLocation
    {
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
