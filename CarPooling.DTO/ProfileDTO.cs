using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class ProfileDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int Talkative { get; set; }
        public bool Allow_smoke { get; set; }
        public bool Allow_pet { get; set; }
        public float GeneralRating { get; set; }
        public float AccuracyRating { get; set; }
        public float TalkativeRating { get; set; }

    }
}
