using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
namespace CarPooling.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date_created { get; set; }
        public char? Gender { get; set; }
        public int? YearofBirth { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
        public Preferences Preferences { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
