using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace CarPooling.DTO
{
    public class GeneralInformationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
        public int? YearofBirth { get; set; }
        public char? Gender { get; set; }
    }
}
