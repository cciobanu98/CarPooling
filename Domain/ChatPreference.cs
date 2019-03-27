using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class ChatPreference
    {
        public int Id { get; set; }
        public Preferences Preferences { get; set; }
        public string Description { get; set; }
    }
}
