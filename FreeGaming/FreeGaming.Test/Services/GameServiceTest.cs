namespace FreeGaming.Test.Services
{
    using Data.Models;
    using Fixtures;
    using FluentAssertions;
    using FreeGaming.Services.Implementaions;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("Service Collection")]
    public class GameServiceTest
    {
        private readonly DatabaseFixture dbFixture;
        private readonly MapperFixture mapperFixture;

        public GameServiceTest(
            DatabaseFixture dbFixture,
            MapperFixture mapperFixture)
        {
            this.dbFixture = dbFixture;
            this.mapperFixture = mapperFixture;
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllGames()
        {
            // Arrange
            GameService gameService = new GameService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            GameService gameService = new GameService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            GameService gameService = new GameService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            await this.dbFixture.AddAsync(new Game { Title = "Test Game" });

            GameService gameService = new GameService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            GameService gameService = new GameService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            bool result = await gameService.ContainsAsync("Test");

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}
