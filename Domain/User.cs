using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
namespace CarPooling.Domain
{
    public class User : IdentityUser
    {
        //public int Id { get; set; } //From IdentityUser
        //public string Username { get; set; } //From UdentityUser
        //public string Email { get; set; } //From IdentyUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; } // From IdentityUser
        public DateTime Date_created { get; set; }
        //public string Phone { get; set; } //From IdentityUser
        public char? Gender { get; set; }
        public int? Age { get; set; }
        public List<MemberCar> Cars { get; set; } = new List<MemberCar>();
        public Preferences Preferences { get; set; }
        public List<Request> Requests { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
