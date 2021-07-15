namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System;

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> role)
        {
            role
                .HasData(new Role
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Publisher",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Publisher"
                });
        }
    }
}
