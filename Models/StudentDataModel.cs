using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMvcProject.Models
{
    public class StudentDataModel
    {
    
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public int PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-2][0-9]|3[01])\/\d{4}$", ErrorMessage = "Invalid date of birth format. Use MM/DD/YYYY.")]
        public DateTime Dob { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "State must contain only letters and spaces.")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City must contain only letters and spaces.")]
        public string City { get; set; }
    }

}
