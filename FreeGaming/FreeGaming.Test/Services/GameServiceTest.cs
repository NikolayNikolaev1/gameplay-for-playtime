namespace FreeGaming.Test.Services
{
    using Data.Models;
    using FluentAssertions;
    using FreeGaming.Data;
    using FreeGaming.Services.Implementaions;
    using System.Threading.Tasks;
    using Xunit;

    public class GameServiceTest
    {
        [Fact]
        public async Task AllAsyncShouldReturnAllGames()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);
            await this.SeedGamesTestDataAsync(dbContext);

            GameService gameService = new GameService(dbContext, mapper);

            // Act
            var result = await gameService.AllAsync();

            // Assert
            result
                .Should()
                .Contain(r => r.Id == 1)
                .And
                .Contain(r => r.Id == 2)
                .And
                .Contain(r => r.Id == 3)
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishedGamesByPublisher()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);
            await this.SeedGamesTestDataAsync(dbContext);

            GameService gameService = new GameService(dbContext, mapper);

            // Act
            var result = await gameService.AllAsync("2");

            // Assert
            result
                .Should()
                .Contain(r => r.Id == 1)
                .And
                .Contain(r => r.Id == 2)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUserGames()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);
            await this.SeedGamesTestDataAsync(dbContext);

            GameService gameService = new GameService(dbContext, mapper);

            // Act
            var result = await gameService.AllAsync("1");

            // Assert
            result
                .Should()
                .Contain(r => r.Id == 1)
                .And
                .Contain(r => r.Id == 3)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task ContainsAsyncShouldReturnTrue()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);
            await this.SeedGamesTestDataAsync(dbContext);

            GameService gameService = new GameService(dbContext, mapper);

            // Act
            bool result = await gameService.ContainsAsync("Test Game");

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public async Task ContainsAsyncShouldReturnFalse()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);
            await this.SeedGamesTestDataAsync(dbContext);

            GameService gameService = new GameService(dbContext, mapper);

            // Act
            bool result = await gameService.ContainsAsync("Test");

            // Assert
            result
                .Should()
                .BeFalse();
        }

        private async Task SeedGamesTestDataAsync(FreeGamingDbContext dbContext)
        {
            await dbContext.AddRangeAsync(
                new Game { Id = 1, Title = "Test Game" },
                new Game { Id = 2 },
                new Game { Id = 3 });

            await dbContext.AddRangeAsync(
                new UserGame { UserId = "2", GameId = 1 },
                new UserGame { UserId = "2", GameId = 2 },
                new UserGame { UserId = "1", GameId = 1 },
                new UserGame { UserId = "1", GameId = 3 });

            await dbContext.SaveChangesAsync();
        }
    }
}
