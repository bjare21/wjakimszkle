using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;


namespace Wjakimszkle.ApplicationServices.API.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int saltSize = 16;
        private const int hashSize = 20;

        public string Hash(string password)
        {
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashedBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 100000,
                numBytesRequested: hashSize);

            byte[] hashSaltBytes = new byte[saltSize + hashSize];

            Array.Copy(salt, 0, hashSaltBytes, 0, saltSize);
            Array.Copy(hashedBytes, 0, hashSaltBytes, saltSize, hashSize);

            string hashed = Convert.ToBase64String(hashSaltBytes);
            return hashed;
        }

        public bool Verify(string hashedPassword, string confirmPassword)
        {
            bool result = true;
            byte[] hashedBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[saltSize];
            Array.Copy(hashedBytes, 0, salt, 0, saltSize);

            var hash = KeyDerivation.Pbkdf2(
                password: confirmPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 100000,
                numBytesRequested: hashSize);

            for (int i = 0; i < hash.Length; i++)
            {
                if (hashedBytes[i + 16] != hash[i]) result = false;
            }

            return result;
        }

    }



}

