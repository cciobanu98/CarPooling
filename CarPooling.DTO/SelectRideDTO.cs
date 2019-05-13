using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.DTO
{
    public class SelectRideDTO
    { 
        [Required(ErrorMessage ="Date is Required")]
        public DateTime TravelStartDateTime { get; set; }
        [HiddenInput]
        [Required(ErrorMessage = "Unable to detect Source")]
        public float SourceLocationLat { get; set; }
        [HiddenInput]
        public float SourceLocationLng { get; set; }
        [HiddenInput]
        public string SourceCity { get; set; }
        [HiddenInput]
        public string SourceStreet { get; set; }
        [HiddenInput]
        public string SourceState { get; set; }
        [HiddenInput]
        public string DestinationCity { get; set; }
        [HiddenInput]
        public string DestinationStreet { get; set; }
        [HiddenInput]
        public string DestinationState { get; set; }
        [HiddenInput]
        [Required(ErrorMessage = "Unable to detect Destination")]
        public float DestinationLocationLat { get; set; }
        [HiddenInput]
        public float DestinationLocationLng { get; set; }
    }
}
