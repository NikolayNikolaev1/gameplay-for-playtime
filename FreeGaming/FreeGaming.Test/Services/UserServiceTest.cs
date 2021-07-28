namespace FreeGaming.Test.Services
{
    using FluentAssertions;
    using FreeGaming.Services.Implementaions;
    using FreeGaming.Services.Models.Users;
    using System.Threading.Tasks;
    using Xunit;

    public class UserServiceTest
    {
        [Fact]
        public async Task ProfileAsyncShouldreturnCorrectUserProfileInfo()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            UserService userService = new UserService(dbContext, mapper);

            // Act
            var result = await userService.ProfileAsync<UserProfileServiceModel>("1");

            // Assert
            result
                .Should()
                .Match<UserProfileServiceModel>(r => r.Id == "1");
        }

        [Fact]
        public async Task ProfileAsyncShouldReturnCorrectPublisherProfileInfo()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            UserService userService = new UserService(dbContext, mapper);

            // Act
            var result = await userService.ProfileAsync<UserProfileServiceModel>("2");

            // Assert
            result
                .Should()
                .Match<UserProfileServiceModel>(r => r.Id == "2");
        }
    }
}
