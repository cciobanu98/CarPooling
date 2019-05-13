using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class SelectedRidesWithDistanceDTO : SelectedRidesDTO
    {
        public float DistanceFromSource { get; set; }
        public float DistanceFromDestination { get; set; }
        public float SourceLatitude { get; set; }
        public float SourceLongitude { get; set; }
        public float DestinationLatitude { get; set; }
        public float DestinationLongitude { get; set; }
    }
}
