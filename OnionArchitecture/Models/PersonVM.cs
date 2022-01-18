using System;
using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.Models
{
    public class PersonVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
