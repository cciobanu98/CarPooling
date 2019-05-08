using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPooling.DTO
{
    public class RideDTO
    {
        public int CarId { get; set; }
        [Required]
        public string SourceStreet { get; set; }
        [Required]
        public string SourceCity { get; set; }
        [Required]
        public string SourceState { get; set; }
        [Required]
        public string DestinationStreet { get; set; }
        [Required]
        public string DestinationCity { get; set; }
        [Required]
        public string DestinationState { get; set; }
        //public string SourceLocation { get; set; }
        //public string DestinationLocation { get; set; }
        public float SourceLocationLat { get; set; }
        public float SourceLocationLng { get; set; }
        public float DestinationLocationLat { get; set; }
        public float DestinationLocationLng { get; set; }
        public string TravelStartDateTime { get; set; }
        public int Seats { get; set; }
    }
}
