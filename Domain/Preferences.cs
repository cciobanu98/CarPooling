using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarPooling.Domain
{
    public class Preferences : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int Talkative { get; set; }
        public bool Allow_smoke { get; set; }
        public bool Allow_pet { get; set; }
    }
}
