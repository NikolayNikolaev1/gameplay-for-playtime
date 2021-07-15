namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> userRole)
        {
            userRole
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            userRole
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            userRole
                .HasData(new UserRole
                {
                    UserId = "06f3dd53-f820-48a8-820b-6841dffb03c8",
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                });

            userRole
                .HasData(new UserRole
                {
                    UserId = "827c261d-3f89-4ccc-be47-59ab57373a05",
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                });

            userRole
                .HasData(new UserRole
                {
                    UserId = "ddba3758-c519-4485-ad66-19e2bd194760",
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                });
        }
    }
}
