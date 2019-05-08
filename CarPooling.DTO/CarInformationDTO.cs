using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class CarInformationDTO
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Seats { get; set; }
        public int Id { get; set; }
    }
}
