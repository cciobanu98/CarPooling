using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPooling.DTO
{
    public class CarInformationDTO
    {
        [Required(ErrorMessage ="You need to indicate car number")]
        public string Number { get; set; }
        [Required(ErrorMessage = "You need to indicate car Model")]
        public string Model { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "You need to indicate number of Seats")]
        public int Seats { get; set; }
        public int Id { get; set; }
    }
}
