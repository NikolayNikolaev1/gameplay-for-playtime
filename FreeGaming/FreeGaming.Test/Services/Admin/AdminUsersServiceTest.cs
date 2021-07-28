namespace FreeGaming.Test.Services.Admin
{
    using FluentAssertions;
    using FreeGaming.Services.Admin.Implementaions;
    using FreeGaming.Services.Admin.Models;
    using FreeGaming.Services.Enums;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class AdminUsersServiceTest
    {

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithNoSpecificPropertyOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, 0, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == "2"
                    && r.ElementAt(1).Id == "3"
                    && r.ElementAt(2).Id == "5")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithAscendingUsernameOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Username, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "AlphaPublisher"
                    && r.ElementAt(1).UserName == "BetaPublisher"
                    && r.ElementAt(2).UserName == "GammaPublisher")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithDescendingUsernameOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Username, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "GammaPublisher"
                    && r.ElementAt(1).UserName == "BetaPublisher"
                    && r.ElementAt(2).UserName == "AlphaPublisher")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithAscendingEmailOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Email, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "alpha@publisher.test"
                    && r.ElementAt(1).Email == "beta@publisher.test"
                    && r.ElementAt(2).Email == "gamma@publisher.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithDescendingEmailOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Email, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "gamma@publisher.test"
                    && r.ElementAt(1).Email == "beta@publisher.test"
                    && r.ElementAt(2).Email == "alpha@publisher.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithNoSpecificPropertyOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, 0, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == "1"
                    && r.ElementAt(1).Id == "6"
                    && r.ElementAt(2).Id == "7")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingUsernameOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Username, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "AlphaUser"
                    && r.ElementAt(1).UserName == "BetaUser"
                    && r.ElementAt(2).UserName == "GammaUser")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithDescendingUsernameOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Username, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "GammaUser"
                    && r.ElementAt(1).UserName == "BetaUser"
                    && r.ElementAt(2).UserName == "AlphaUser")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAScendingEmailOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Email, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "alpha@test.test"
                    && r.ElementAt(1).Email == "beta@test.test"
                    && r.ElementAt(2).Email == "gamma@test.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingEmailOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Email, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "gamma@test.test"
                    && r.ElementAt(1).Email == "beta@test.test"
                    && r.ElementAt(2).Email == "alpha@test.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingRaitingOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Raiting, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Rating == 7
                    && r.ElementAt(1).Rating == 12
                    && r.ElementAt(2).Rating == 26)
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithDescendingRaitingOrder()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Raiting, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Rating == 26
                    && r.ElementAt(1).Rating == 12
                    && r.ElementAt(2).Rating == 7)
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task CountAsyncShouldReturnTotalPublishersNumber()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService
                .CountAsync(UserRoleType.Publisher);

            // Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public async Task CountAsyncShouldReturnTotalUsersWithNoRoleNumber()
        {
            // Arrange
            var dbContext = Testing.CreateDatabaseContext();
            var mapper = Testing.CreateMapper();

            await Testing.SeedUsersWithRolesTestDataAsync(dbContext);

            AdminUsersService adminUsersService = new AdminUsersService(dbContext, mapper);

            // Act
            var result = await adminUsersService
                .CountAsync(UserRoleType.Player);

            // Assert
            result
                .Should()
                .Equals(3);
        }
    }
}
