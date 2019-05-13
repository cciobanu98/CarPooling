using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPooling.DTO
{
    public class RatingDTO
    {
        [HiddenInput]
        public int Id { get; set; }
        [Range(1,10)]
        public int General { get; set; }
        [Range(1, 10)]
        public int Talkative { get; set; }
        [Range(1, 10)]
        public int Accuracy { get; set; }
        [HiddenInput]
        public int rideId { get; set; }
    }
}
