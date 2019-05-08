using System;


namespace CarPooling.DTO
{
    public class SelectedRidesDTO
    {
        public int Id { get; set; }
        public float DistanceFromSource { get; set; }
        public float DistanceFromDestination { get; set; }
        public int Price { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Seats { get; set; }
        public DateTime TravelStartDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
