using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Request
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public int EnrouteLocationId { get; set; }
        public Location EnrouteLocation { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
