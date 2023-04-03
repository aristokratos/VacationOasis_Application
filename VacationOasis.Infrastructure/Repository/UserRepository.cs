using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;
using VacationOasis.Infrastructure.IRepository;

namespace VacationOasis.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> Register(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand("spAddToUser", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.Parameters.AddWithValue("@FistName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@FullName", user.FullName);
            command.Parameters.AddWithValue("@Created", user.created);

            await command.ExecuteNonQueryAsync();

            return true;
        }

        public async Task<List<User>> GetAllLogin()
        {
            var users = new List<User>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand("dbo.spLogin", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var user = new User(
                    reader.GetString("UserEmail"),
                    reader.GetString("UserPassword"),
                    reader.GetString("UserFirstName"),
                    reader.GetString("UserLastName")
                )
                {
                    UserId = reader.GetString("UserId"),
                    created = reader.GetDateTime("DateCreated"),
                    FullName = reader.GetString("UserFullName")
                };
                users.Add(user);
            }


            return users;
        }

        public async Task<User?> Login(string email, byte[] passwordHash)
        {
            var users = await GetAllLogin();

            string passwordHashString = BitConverter.ToString(passwordHash).Replace("-", "");
            return users.FirstOrDefault(x => x.Email == email && x.Password == passwordHashString);
        }


    }
}
