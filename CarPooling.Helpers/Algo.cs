using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Helpers
{
    public class Algo
    {
        public static MinMaxLocation GetMinMax(Coordinates c)
        {
            MinMaxLocation temp = new MinMaxLocation();
            temp.minLat = c.Lat - 1;
            temp.maxLat = c.Lat + 1;
            temp.minLong = c.Long - 1;
            temp.maxLong = c.Long + 1;
            return temp;
        }
        private static double deg2rad(float deg)
        {
            return deg * (Math.PI / 180);
        }
        public static float GetDistanceInKm(Coordinates c1, Coordinates c2)
        {
            int R = 6371; // Radius of earth in km
            Coordinates dc = new Coordinates();
            dc.Lat = (float)deg2rad(c1.Lat - c2.Lat);
            dc.Long = (float)deg2rad(c1.Long - c2.Long);
            var a = Math.Sin(dc.Lat / 2) * Math.Sin(dc.Lat / 2) +
                    Math.Cos(deg2rad(c1.Lat)) * Math.Cos(deg2rad(c2.Lat)) *
                    Math.Sin(dc.Long / 2) * Math.Sin(dc.Long / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return (float)d;
        }
    }
}
