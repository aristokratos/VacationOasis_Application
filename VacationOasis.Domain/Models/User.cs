using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationOasis.Domain.Models
{
    public class User
    {
        private byte[] passwordHash;

        [BindNever]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Enter Your First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Enter Your Last Name")]
        public string LastName { get; set; }
        = string.Empty;

        [Required(ErrorMessage ="Enter Your Email Address")] 
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Your Password")]
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public DateTime updated { get; set; }

        public User(string Email, string Password, string FirstName, string LastName)
        {
            UserId = Guid.NewGuid().ToString();
            this.Email = Email;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FullName = FirstName + " " + LastName;
        }

        public User(string email, byte[] passwordHash, string firstName, string lastName)
        {
            Email = email;
            this.passwordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
