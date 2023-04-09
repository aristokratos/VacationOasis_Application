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
using VacationOasis.Core.Interface;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using VacationOasis.Infrastructure.Repository;

namespace VacationOasis.Core.Services
{

public class UserServices : IUserService
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
        public async Task<User> TryAuthenticate(string email, string password)
        {
            // Retrieve the user from the repository using the email address
            User user = await _repository.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }

            // Retrieve the stored salt and hash for the user's password
            byte[] storedSalt = Convert.FromBase64String(user.PasswordSalt);
            byte[] storedHash = Convert.FromBase64String(user.PasswordHash);

            // Derive a key from the user's password and the stored salt
            Pkcs5S2ParametersGenerator generator = new Pkcs5S2ParametersGenerator(new Sha256Digest());
            generator.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()), storedSalt, 10000);
            KeyParameter key = (KeyParameter)generator.GenerateDerivedMacParameters(256);

            // Compute the hash of the derived key
            Sha256Digest digest = new Sha256Digest();
            byte[] computedHash = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(key.GetKey(), 0, key.GetKey().Length);
            digest.DoFinal(computedHash, 0);

            // Compare the computed hash to the stored hash
            if (!computedHash.SequenceEqual(storedHash))
            {
                return null;
            }

            // Authentication successful, return the user
            return user;
        }

    }

}

