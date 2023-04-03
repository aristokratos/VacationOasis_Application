using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;

namespace VacationOasis.Infrastructure.IRepository
{
    public interface IUserRepository
    {
        Task<bool> Register(User user);
        Task<List<User>> GetAllLogin();
       // Task<User> Login(string Email,  string Password);
        Task<User> Login(string email, byte[] passwordHash);
    }
}
