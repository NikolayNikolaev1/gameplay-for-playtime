namespace FreeGaming.Test.Services.Admin
{
    using Data.Models;
    using Fixtures;
    using FluentAssertions;
    using FreeGaming.Services.Admin.Implementaions;
    using FreeGaming.Services.Admin.Models;
    using FreeGaming.Services.Enums;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class AdminUsersServiceTest : IClassFixture<DatabaseFixture>, IClassFixture<MapperFixture>
    {
        private readonly DatabaseFixture dbFixture;
        private readonly MapperFixture mapperFixture;

        public AdminUsersServiceTest(
            DatabaseFixture dbFixture,
            MapperFixture mapperFixture)
        {
            this.dbFixture = dbFixture;
            this.mapperFixture = mapperFixture;
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithNoSpecificPropertyOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Username, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "Alpha"
                    && r.ElementAt(1).UserName == "Beta"
                    && r.ElementAt(2).UserName == "Gamma")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithDescendingUsernameOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Username, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).UserName == "Gamma"
                    && r.ElementAt(1).UserName == "Beta"
                    && r.ElementAt(2).UserName == "Alpha")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithAscendingEmailOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Email, OrderDirectionType.Ascending);

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
        public async Task AllAsyncShouldReturnAllPublishersWithDescendingEmailOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminPublisherListingServiceModel>(
                UserRoleType.Publisher, UserProperty.Email, OrderDirectionType.Descending);

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
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithNoSpecificPropertyOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Email, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "alphauser@test.test"
                    && r.ElementAt(1).Email == "betauser@test.test"
                    && r.ElementAt(2).Email == "gammauser@test.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingEmailOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Email, OrderDirectionType.Descending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Email == "gammauser@test.test"
                    && r.ElementAt(1).Email == "betauser@test.test"
                    && r.ElementAt(2).Email == "alphauser@test.test")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingRaitingOrder()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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

        [Fact] // Test need refactoring. Remove for logic in arrange
        public async Task AllAsyncShouldReturnUsersWithNoRoleAndWithNoOrderForSecondPage()
        {
            // Arrange
            for (int i = 11; i <= 25; i++)
            {
                await this.dbFixture.Context
                    .AddAsync(new User { Id = i.ToString() });
            }

            await this.dbFixture.Context.SaveChangesAsync();

            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, 0, OrderDirectionType.Ascending, 2);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == "21"
                    && r.ElementAt(1).Id == "22"
                    && r.ElementAt(2).Id == "23"
                    && r.ElementAt(3).Id == "24"
                    && r.ElementAt(4).Id == "25")
                .And
                .HaveCount(5);
        }

        [Fact]
        public async Task CountAsyncShouldReturnTotalPublishersNumber()
        {
            // Arrange
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
            AdminUsersService adminUsersService = new AdminUsersService(
                this.dbFixture.Context, this.mapperFixture.Mapper);

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
