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
        public City SourceCity { get; set; }
        public City DestinationCity { get; set; }
        public List<City> EnrouteCities { get; set; } = new List<City>();
        public int Price { get; set; }
        public List<Request> Requests { get; set; }
    }
}
