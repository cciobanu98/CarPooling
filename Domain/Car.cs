using System.Collections.Generic;
namespace CarPooling.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Seats { get; set; }
        public string CarNumbers { get; set; }
        public List<MemberCar> MemberCars { get; set; } = new List<MemberCar>();
    }
}
