using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Ride : IEntity<int>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime TravelStartDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? SourceLocationId { get; set; }
        public Location SourceLocation { get; set; }
        public int? DestinationLocationId { get; set; }
        public Location DestinationLocation { get; set; }
        public int Price { get; set; }
        public int Seats { get; set; }
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public string Description { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
