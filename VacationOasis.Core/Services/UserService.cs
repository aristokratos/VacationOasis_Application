using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Infrastructure.IRepository;
// using BouncyCastle.Cryptography;
// using BouncyCastle.Utilities.Encoders;
using VacationOasis.Domain.Models;

namespace VacationOasis.Core.Services
{

public class UserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> RegisterUser(string email, string password, string firstName, string lastName)
        {
            byte[] passwordHash = HashPassword(password);
            User newUser = new User(email, passwordHash, firstName, lastName);
            bool isRegistered = await _repository.Register(newUser);

            if (isRegistered)
            {
                return newUser;
            }

            return null;
        }

        public async Task<User> Login(string email, string password)
        {
            byte[] passwordHash = HashPassword(password);
            return await _repository.Login(email, passwordHash);
        }

        private byte[] HashPassword(string password)
        {
            var sha256 = new Sha256Digest();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = new byte[sha256.GetDigestSize()];
            sha256.BlockUpdate(passwordBytes, 0, passwordBytes.Length);
            sha256.DoFinal(hash, 0);
            return hash;
        }
    }

}

