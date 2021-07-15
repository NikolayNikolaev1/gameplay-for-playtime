namespace FreeGaming.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System;
    using System.Collections.Generic;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string Password = "publisher";

        public void Configure(EntityTypeBuilder<User> user)
        {
            IEnumerable<User> publishers = new List<User>
            {
                new User
                {
                    Id = "06f3dd53-f820-48a8-820b-6841dffb03c8",
                    UserName = "Blizzard Entertainment",
                    Email = "blizzard@freegaming.test",
                    RegistrationDate = DateTime.UtcNow
                },
                new User
                {
                    Id = "827c261d-3f89-4ccc-be47-59ab57373a05",
                    UserName = "Rockstar Games",
                    Email = "rockstargames@freegaming.test",
                    RegistrationDate = DateTime.UtcNow
                },
                new User
                {
                    Id = "ddba3758-c519-4485-ad66-19e2bd194760",
                    UserName = "Capcom",
                    Email = "capcom@freegaming.test",
                    RegistrationDate = DateTime.UtcNow,
                }
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            foreach (User publisher in publishers)
            {
                passwordHasher.HashPassword(publisher, Password);
                user.HasData(publisher);
            }
        }
    }
}
