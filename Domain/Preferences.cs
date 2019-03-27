using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class Preferences
    {
        public int Id { get; set; }
        public User User { get; set; }
        public bool? Allow_smoke { get; set; }
        public bool? Allow_pet { get; set; }
        public int? MusicPreferenceId { get; set; }
        public MusicPreference MusicPreference { get; set; }
        public int? ChatPreferenceId { get; set; }
        public ChatPreference ChatPreference { get; set; }

    }
}
