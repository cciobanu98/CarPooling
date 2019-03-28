using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Preferences
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
    }
}
