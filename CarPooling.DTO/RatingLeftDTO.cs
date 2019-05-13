using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class RatingLeftDTO
    {
        public int RatingId { get; set; }
        public int General { get; set; }
        public int Accuracy { get; set; }
        public int Talkative { get; set; }
        public string LeftFor{ get; set; }
    }
}
