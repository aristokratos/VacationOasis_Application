﻿using System.ComponentModel.DataAnnotations;

namespace VacationOasis.Models
{
    public class UserRegistrationDetails
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[\S]{8,13}$",
        ErrorMessage = "The password greater than 7 and less than 12")]
        public string Password { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$",
        ErrorMessage = "LastName must start with a capital Letter")]
        public string LastName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$",
         ErrorMessage = "FirstName must start with a capital Letter")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Retype your password")]
        public string RetypePassword { get; set; }
    }
}
