using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace DataAccess.DataSeed
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            byte[] passwordHash, passwordSalt;

            SaltFunc.CreatePasswordHash("123", out passwordHash, out passwordSalt);

            builder.ToTable("User");
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    Email = "sezer.tanci@gmail.com",
                    FirstName = "Sezer",
                    LastName = "Tancı",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                }
            );
        }
    }
}
