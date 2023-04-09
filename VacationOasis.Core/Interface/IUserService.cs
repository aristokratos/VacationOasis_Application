using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;

namespace VacationOasis.Core.Interface
{
    public interface IUserService
    {
        //Task<User> Login(string username, byte[] passwordHash);
        Task<User> Login(string email, string password);
        Task<User> RegisterUser(string email, string password, string firstName, string lastName);
       // Task<User> RegisterUser(string email,  string password, string FirstName, string LastName);
        Task<User> TryAuthenticate(string email, string password);
    }
}
