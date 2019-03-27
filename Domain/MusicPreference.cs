using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class MusicPreference
    {
        public int Id { get; set; }
        public Preferences Preferences { get; set; }
        public int? Volume { get; set; }
        public string Description { get; set; }
    }
}
