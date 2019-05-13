using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarPooling.Domain
{
    public class Location : IEntity<int>
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public Request RequestSource { get; set; }
        public Request RequestDestination { get; set; }
    }
}
