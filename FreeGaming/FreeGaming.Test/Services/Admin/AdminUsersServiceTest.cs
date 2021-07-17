namespace FreeGaming.Test.Services.Admin
{
    using Data.Models;
    using FluentAssertions;
    using FreeGaming.Services.Admin.Implementaions;
    using FreeGaming.Services.Admin.Models;
    using FreeGaming.Services.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class AdminUsersServiceTest : ServiceTests
    {
        [Fact]
        public async Task AllAsyncShouldReturnAllPublishersWithNoSpecificPropertyOrder()
        {
            // Arrange
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, 0, OrderDirectionType.Ascending);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == "1"
                    && r.ElementAt(1).Id == "3"
                    && r.ElementAt(2).Id == "4")
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAscendingUsernameOrder()
        {
            // Arrange
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Username, OrderDirectionType.Ascending);

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
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithDescendingUsernameOrder()
        {
            // Arrange
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, UserProperty.Username, OrderDirectionType.Descending);

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
        public async Task AllAsyncShouldReturnAllUsersWithNoRoleAndWithAScendingEmailOrder()
        {
            // Arrange
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
        public async Task AllAsyncShouldReturnUsersWithNoRoleAndWithNoOrderForSecondPage()
        {
            for (int i = 1; i <= 15; i++)
            {
                await base.DbContext
                    .AddAsync(new User { Id = i.ToString() });
            }

            await base.DbContext.SaveChangesAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

            // Act
            var result = await adminUsersService.AllAsync<AdminUserListingServiceModel>(
                UserRoleType.Player, 0, OrderDirectionType.Ascending, 2);

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == "11"
                    && r.ElementAt(1).Id == "12"
                    && r.ElementAt(2).Id == "13"
                    && r.ElementAt(3).Id == "14"
                    && r.ElementAt(4).Id == "15")
                .And
                .HaveCount(5);
        }

        [Fact]
        public async Task CountAsyncShouldReturnTotalPublishersNumber()
        {
            // Arrange
            await this.SeedTestRolesAsync();
            await this.SeedTestPublishersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

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
            await this.SeedTestRolesAsync();
            await this.SeedTestUsersAsync();

            AdminUsersService adminUsersService = new AdminUsersService(base.DbContext, base.Mapper);

            // Act
            var result = await adminUsersService
                .CountAsync(UserRoleType.Player);

            // Assert
            result
                .Should()
                .Equals(3);
        }

        private async Task SeedTestRolesAsync()
        {
            await base.DbContext.AddRangeAsync(
                new Role { Id = "1", Name = "Administrator" },
                new Role { Id = "2", Name = "Publisher" });

            await base.DbContext.SaveChangesAsync();
        }

        private async Task SeedTestPublishersAsync()
        {
            await base.DbContext
                .AddRangeAsync(
               new User { Id = "1" },
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
               });

            await base.DbContext.SaveChangesAsync();
        }

        private async Task SeedTestUsersAsync()
        {
            await base.DbContext.AddRangeAsync(
               new User { Id = "1", UserName = "Gamma", Email = "alpha@test.test", Rating = 12 },
               new User
               {
                   Id = "2",
                   Roles = new List<UserRole>
                   {
                        new UserRole
                        {
                            UserId = "2",
                            RoleId = "2"
                        }
                   }
               },
               new User { Id = "3", UserName = "Alpha", Email = "beta@test.test", Rating = 26 },
               new User { Id = "4", UserName = "Beta", Email = "gamma@test.test", Rating = 7 });

            await base.DbContext.SaveChangesAsync();
        }
    }
}
