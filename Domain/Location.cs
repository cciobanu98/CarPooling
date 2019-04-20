using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public Request Request { get; set; }

    }
}
