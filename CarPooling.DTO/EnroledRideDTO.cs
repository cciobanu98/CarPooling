using CarPooling.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class EnroledRideDTO
    {
        public string From { get; set; }
        public string Where { get; set; }
        public DateTime Date { get; set; }
        public string[] PassengersName { get; set; }
        public string[] PassengersId { get; set; }
        public string Rider { get; set; }
        public int Price { get; set; }
        public int RideId { get; set; }
        public int RatingId { get; set; }
    }
}
