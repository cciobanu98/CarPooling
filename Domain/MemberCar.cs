using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class MemberCar
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
