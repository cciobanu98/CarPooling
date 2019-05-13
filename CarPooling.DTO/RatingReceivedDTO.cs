using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTO
{
    public class RatingReceivedDTO
    {
        public int General { get; set; }
        public int Talkative { get; set; }
        public int Accuracy { get; set; }
        public string ReceivedFrom { get; set; }
    }
}
