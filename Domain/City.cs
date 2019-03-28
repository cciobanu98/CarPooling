using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Request Request { get; set; }

    }
}
