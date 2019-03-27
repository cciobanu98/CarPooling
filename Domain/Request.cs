using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Request
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public Ride Ride { get; set; }
        public int EnrouteCityId { get; set; }
        public City EnrouteCity { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public User Requester { get; set; }
    }
}
