using CleanArchitecture.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Secutiry
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;

        public string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }
    }
}