using System;
using System.Collections.Generic;
using System.Text;
using CarPooling.Domain;

namespace CarPooling.DTO
{
    public class RideInformationDTO
    {
        public int RideId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string SourceAddress { get; set; }
        public string SourceCity { get; set; }
        public string SourceState { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
        public string Talkative { get; set; }
        public string Pets { get; set; }
        public string Music { get; set; }
        public string Smoking { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public float Price { get; set; }
        public List<User> Passengers { get; set; }
    }
}
