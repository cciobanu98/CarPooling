using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Domain
{
    public class GeneralPreferences : Preferences
    {
        public bool? Allow_smoke { get; set; }
        public bool? Allow_pet { get; set; }
    }
}
