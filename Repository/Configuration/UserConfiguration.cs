using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.models;

namespace TodoList.Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        string HashPassword(string password, out byte[] salt)
        {

            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);


            return Convert.ToHexString(hash);
            
        }
        
        bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        builder.HasData(

            new User {
                    Id = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                    Username = "example",
                    Password = HashPassword("example1", out var salt),
                    Salt = Convert.ToHexString(salt),
                    Email = "user@gmail.com",
                    CreatedOn = DateTime.UtcNow,
            },
            new User
            {
                Id = Guid.Parse("596767dc-c295-4dc9-ae79-4e80796f51db"),
                Username = "user2",
                Password = HashPassword("example2", out salt),
                Salt = Convert.ToHexString(salt),
                Email = "user2@gmail.com",
                CreatedOn = DateTime.UtcNow
            }
        );
    }
}