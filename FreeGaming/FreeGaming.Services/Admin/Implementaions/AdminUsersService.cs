namespace FreeGaming.Services.Admin.Implementaions
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Enums;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Common.WebConstants;

    public class AdminUsersService : IAdminUsersService
    {
        private readonly FreeGamingDbContext dbContext;
        private readonly IMapper mapper;

        public AdminUsersService(FreeGamingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method returns the desired user service model, based on what role it is presented in the parameters.
        /// Also returns ordered property and given range by page.
        /// </summary>
        /// <typeparam name="TUserServiceModel">Generic type for the base user lsiting service model of the abstract class</typeparam>
        /// <param name="role">Specified user role.</param>
        /// <param name="property">Specified property to order.</param>
        /// <param name="orderDirection">Specified order direction.</param>
        /// <param name="page">Specified page of users.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TUserListingServiceModel>> AllAsync<TUserListingServiceModel>(
            UserRoleType role,
            UserProperty property,
            OrderDirectionType orderDirection,
            int page = 1)
            where TUserListingServiceModel : AdminBaseListingServiceModel, new()
        {
            var users = this.dbContext
                .Users
                .AsQueryable();

            switch (property)
            {
                case UserProperty.Username:
                    users = (orderDirection == OrderDirectionType.Ascending
                        ? users.OrderBy(u => u.UserName)
                        : users.OrderByDescending(u => u.UserName))
                        .AsQueryable();
                    break;
                case UserProperty.Email:
                    users = (orderDirection == OrderDirectionType.Ascending
                        ? users.OrderBy(u => u.Email)
                        : users.OrderByDescending(u => u.Email))
                        .AsQueryable();
                    break;
                case UserProperty.Raiting:
                    users = (orderDirection == OrderDirectionType.Ascending
                        ? users.OrderBy(u => u.Rating)
                        : users.OrderByDescending(u => u.Rating))
                        .AsQueryable();
                    break;
            }

            switch (role)
            {
                case UserRoleType.Player:
                    users = users
                        .Where(u => !u.Roles.Any())
                        .AsQueryable();
                    break;
                case UserRoleType.Publisher:
                    users = users
                        .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                        .AsQueryable();
                    break;
            }

            return await users
                .ProjectTo<TUserListingServiceModel>(this.mapper.ConfigurationProvider)
                .Skip((page - 1) * UsersPageSize)
                .Take(UsersPageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync(UserRoleType role)
        {
            switch (role)
            {
                case UserRoleType.Player:
                    return await this.dbContext
                        .Users
                        .Where(u => !u.Roles.Any())
                        .CountAsync();
                case UserRoleType.Publisher:
                    return await this.dbContext
                        .Users
                        .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                        .CountAsync();
                default:
                    return 0;
            }
        }
    }
}
