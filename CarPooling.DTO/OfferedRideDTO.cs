using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class OfferedRideDTO
    {
        public string From { get; set; }
        public string Where { get; set; }
        public DateTime Date { get; set; }
        public string[] PassengersName { get; set; }
        public string[] PassengersId { get; set; }
        public int Price { get; set; }
    }
}
