namespace FreeGaming.Test
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class Testing
    {
        public static FreeGamingDbContext CreateDatabaseContext()
            => new FreeGamingDbContext(
                new DbContextOptionsBuilder<FreeGamingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

        public static IMapper CreateMapper()
            => new MapperConfiguration(
                cfg => cfg.AddProfile<AutoMapperProfile>())
                .CreateMapper();

        public static async Task SeedUsersWithRolesTestDataAsync(FreeGamingDbContext dbContext)
        {
            await dbContext.AddRangeAsync(
                new Role { Id = "1", Name = "Publisher" },
                new Role { Id = "2", Name = "Administrator" });

            await dbContext.AddRangeAsync(
                new User { Id = "1", UserName = "AlphaUser", Email = "gamma@test.test", Rating = 12 },
                new User { Id = "2", UserName = "GammaPublisher", Email = "beta@publisher.test" },
                new User { Id = "3", UserName = "AlphaPublisher", Email = "gamma@publisher.test" },
                new User { Id = "4" },
                new User { Id = "5", UserName = "BetaPublisher", Email = "alpha@publisher.test" },
                new User { Id = "6", UserName = "BetaUser", Email = "beta@test.test", Rating = 26 },
                new User { Id = "7", UserName = "GammaUser", Email = "alpha@test.test", Rating = 7 });

            await dbContext.AddRangeAsync(
                new UserRole { UserId = "2", RoleId = "1" },
                new UserRole { UserId = "3", RoleId = "1" },
                new UserRole { UserId = "4", RoleId = "2" },
                new UserRole { UserId = "5", RoleId = "1" });

            await dbContext.SaveChangesAsync();
        }
    }
}
