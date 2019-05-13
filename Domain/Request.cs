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
        public DateTime CreatedDateTime { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool? IsRead { get; set; }
        public int SourceId { get; set; }
        public Location Source { get; set; }
        public int DestinationId { get; set; }
        public Location Destination { get; set; }

    }
}
