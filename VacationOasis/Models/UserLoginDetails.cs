using System.ComponentModel.DataAnnotations;

namespace VacationOasis.Models
{
    public class UserLoginDetails
    {
        [Required
        (ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password greater than 7 and less than 12")]
        public string Password { get; set; }
        public string FullName { get; set; }
        public UserLoginDetails(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
