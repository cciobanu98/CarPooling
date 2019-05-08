using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Helpers
{
    public class Coordinates
    {
        public Coordinates()
        {
            Lat = 0;
            Long = 0;
        }
        public Coordinates(float? Lat, float? Long)
        {
            this.Lat = (float)Lat;
            this.Long = (float)Long;
        }
        public float Lat;
        public float Long;
    }
}
