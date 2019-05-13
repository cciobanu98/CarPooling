using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Rating
    {
        public int Id { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int General { get; set; }
        public int Accuracy { get; set; }
        public int Talkative { get; set; }
    }
}
