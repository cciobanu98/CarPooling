using System;
using System.Collections.Generic;
namespace CarPooling.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime Date_created { get; set; }
        public string Phone { get; set; }
        public char? Gender { get; set; }
        public int? Age { get; set; }
        public List<MemberCar> Cars { get; set; } = new List<MemberCar>();
        public Preferences Preferences { get; set; }
        public Request Request { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
