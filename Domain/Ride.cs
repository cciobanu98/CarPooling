using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Ride
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime TravelStartDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        //public int SourceCityId { get; set; }
        public City SourceCity { get; set; }
        //public int DestinationCityId { get; set; }
        public City DestinationCity { get; set; }
        public List<EnrouteCity> EnrouteCities { get; set; } = new List<EnrouteCity>();
        public int Price { get; set; }
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
