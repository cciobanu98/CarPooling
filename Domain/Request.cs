using System;
using CarPooling.Helpers;

namespace CarPooling.Domain
{
    public class Request : IEntity<int>
    {
        public int Id { get; set; }
        public RequestStatus Status { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        //public int? EnrouteLocationId { get; set; }
        //public Location EnrouteLocation { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool? IsRead { get; set; }
    }
}
