using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.DTO
{
    public class RideDTO
    {
        [Required(ErrorMessage ="You need a car")]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Unable to detect Street<br />")]
        [HiddenInput]
        public string SourceStreet { get; set; }
        [Required(ErrorMessage = "Unable to detect City<br />")]
        [HiddenInput]
        public string SourceCity { get; set; }
        [Required(ErrorMessage = "Unable to detect Country<br />")]
        [HiddenInput]
        public string SourceState { get; set; }
        [Required(ErrorMessage = "Unable to detect Street<br />")]
        [HiddenInput]
        public string DestinationStreet { get; set; }
        [Required(ErrorMessage = "Unable to detect City<br />")]
        [HiddenInput]
        public string DestinationCity { get; set; }
        [Required(ErrorMessage = "Unable to detect Country<br />")]
        [HiddenInput]
        public string DestinationState { get; set; }
        [HiddenInput]
        [Required(ErrorMessage = "Unable to detect Latitude<br />")]
        public float SourceLocationLat { get; set; }
        [HiddenInput]
        [Required(ErrorMessage = "Unable to detect Longitude<br />")]
        public float SourceLocationLng { get; set; }
        [HiddenInput]
        [Required(ErrorMessage = "Unable to detect Latitude<br />")]
        public float DestinationLocationLat { get; set; }
        [Required(ErrorMessage = "Unable to detect Longitude<br />")]
        [HiddenInput]
        public float DestinationLocationLng { get; set; }
        [Required(ErrorMessage ="Ride Date is Required")]
        public DateTime TravelStartDate { get; set; }
        [Required(ErrorMessage ="Number of Seats is Required")]
        public int Seats { get; set; }
        [Required(ErrorMessage ="Price is Required")]
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
