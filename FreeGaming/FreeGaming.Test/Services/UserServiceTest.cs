namespace FreeGaming.Test.Services
{
    using Fixtures;
    using FluentAssertions;
    using FreeGaming.Services.Implementaions;
    using FreeGaming.Services.Models.Users;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("Service Collection")]
    public class UserServiceTest
    {
        private readonly DatabaseFixture dbFixture;
        private readonly MapperFixture mapperFixture;

        public UserServiceTest(
            DatabaseFixture dbFixture,
            MapperFixture mapperFixture)
        {
            this.dbFixture = dbFixture;
            this.mapperFixture = mapperFixture;
        }

        [Fact]
        public async Task ProfileAsyncShouldreturnCorrectUserProfileInfo()
        {
            // Arrange
            UserService userService = new UserService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await userService.ProfileAsync<UserProfileServiceModel>("1");

            // Assert
            result
                .Should()
                .Match<UserProfileServiceModel>(r => r.Id == "1");
        }

        [Fact]
        public async Task ProfileAsyncShouldreturnCorrectPublisherProfileInfo()
        {
            // Arrange
            UserService userService = new UserService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await userService.ProfileAsync<UserProfileServiceModel>("2");

            // Assert
            result
                .Should()
                .Match<UserProfileServiceModel>(r => r.Id == "2");
        }
    }
}
