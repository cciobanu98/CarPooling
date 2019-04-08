using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarPooling.Domain
{
    public class Preferences
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
    }
}
