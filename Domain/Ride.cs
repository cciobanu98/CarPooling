using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Ride
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime TravelStartDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        //public int SourceCityId { get; set; }
        public int SourceLocationId { get; set; }
        public Location SourceLocation { get; set; }
        //public int DestinationCityId { get; set; }
        public int DestinationLocationId { get; set; }
        public Location DestinationLocation { get; set; }
        public List<EnrouteLocation> EnrouteLocations { get; set; } = new List<EnrouteLocation>();
        public int Price { get; set; }
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
