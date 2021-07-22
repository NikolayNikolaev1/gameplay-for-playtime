namespace FreeGaming.Test.Fixtures
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DatabaseFixture
    {
        public DatabaseFixture()
        {
            this.InitializeDatabase();
            // Initialize data.
            this.SeedTestRoles();
            this.SeedTestUsers();
            this.SeedTestGames();
            this.SeedTestUserGames();
        }

        public FreeGamingDbContext Context { get; private set; }

        public async Task AddAsync<TEntity>(TEntity entity)
           where TEntity : class
        {
            await this.Context.AddAsync(entity);
            await this.Context.SaveChangesAsync();
        }

        private void InitializeDatabase()
            => this.Context = new FreeGamingDbContext(
                new DbContextOptionsBuilder<FreeGamingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

        private void SeedTestRoles()
        {
            this.Context.AddRange(
                new Role { Id = "1", Name = "Administrator" },
                new Role { Id = "2", Name = "Publisher" });

            this.Context.SaveChanges();
        }

        private void SeedTestUsers()
        {
            this.Context
                .AddRange(
                new User { Id = "1", UserName = "GammaUser", Email = "alphauser@test.test", Rating = 12 },
               new User
               {
                   Id = "2",
                   UserName = "Beta",
                   Email = "alpha@test.test",
                   Roles = new List<UserRole>
                   {
                        new UserRole
                        {
                            UserId = "2",
                            RoleId = "2"
                        }
                   }
               },
               new User
               {
                   Id = "3",
                   UserName = "Alpha",
                   Email = "beta@test.test",
                   Roles = new List<UserRole>
                   {
                        new UserRole
                        {
                            UserId = "3",
                            RoleId = "2"
                        }
                   }
               },
               new User
               {
                   Id = "4",
                   Roles = new List<UserRole>
                   {
                        new UserRole
                        {
                            UserId = "4",
                            RoleId = "1"
                        }
                   }
               },
               new User
               {
                   Id = "5",
                   UserName = "Gamma",
                   Email = "gamma@test.test",
                   Roles = new List<UserRole>
                   {
                        new UserRole
                        {
                            UserId = "5",
                            RoleId = "2"
                        }
                   }
               },
               new User { Id = "6", UserName = "AlphaUser", Email = "betauser@test.test", Rating = 26 },
               new User { Id = "7", UserName = "BetaUser", Email = "gammauser@test.test", Rating = 7 });

            this.Context.SaveChanges();
        }

        private void SeedTestGames()
        {
            this.Context
                .AddRange(
                new Game
                {
                    Id = 1,
                    Title = "Alpha Game",
                    PublisherId = "2"
                },
                new Game
                {
                    Id = 2,
                    Title = "Beta Game",
                    PublisherId = "2"
                },
                new Game
                {
                    Id = 3,
                    Title = "Gamma Game",
                    PublisherId = "3"
                });

            this.Context.SaveChanges();
        }

        private void SeedTestUserGames()
        {
            this.Context
                .AddRange(
                new UserGame
                {
                    UserId = "1",
                    GameId = 1
                },
                new UserGame
                {
                    UserId = "1",
                    GameId = 3
                });

            this.Context.SaveChanges();
        }
    }
}
