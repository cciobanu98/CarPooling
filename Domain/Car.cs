using System.Collections.Generic;
namespace CarPooling.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Seats { get; set; }
        public string Number { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
       // public List<Ride> Rides { get; set; } = new List<Ride>();
    }
}
