using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
