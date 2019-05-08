using System;
using CarPooling.Domain;
namespace CarPooling.DTO
{
    public class RequestDTO
    {
        public string Requester { get; set; }
        public int RideId { get; set; }
        public User User { get; set; }
    }
}
