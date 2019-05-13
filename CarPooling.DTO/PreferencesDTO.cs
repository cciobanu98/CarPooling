using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPooling.DTO
{
    public class PreferencesDTO
    {
        public string Description { get; set; }
        [Range(0,10)]
        public int Music { get; set; }
        [Range(0, 10)]
        public int Talkative { get; set; }
        [Display(Name = "Pets are allowed?")]
        public bool Pets { get; set; }
        [Display(Name = "Smoking are allowed?")]
        public bool Smoking { get; set; }
    }
}
