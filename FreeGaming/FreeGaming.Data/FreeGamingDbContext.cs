namespace FreeGaming.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Reflection;

    public class FreeGamingDbContext : IdentityDbContext<User, Role, string,
        IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public FreeGamingDbContext(DbContextOptions<FreeGamingDbContext> options)
            : base(options) { }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Using reflection for property relations configuration.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
