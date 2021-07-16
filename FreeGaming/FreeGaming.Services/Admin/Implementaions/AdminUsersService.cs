namespace FreeGaming.Services.Admin.Implementaions
{
    using AutoMapper;
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

            switch (orderDirection)
            {
                case OrderDirectionType.Ascending:
                    switch (property)
                    {
                        case UserProperty.Username:
                            users = users
                                .OrderBy(u => u.UserName)
                                .AsQueryable();
                            break;
                        case UserProperty.Email:
                            users = users
                                .OrderBy(u => u.Email)
                                .AsQueryable();
                            break;
                        case UserProperty.Raiting:
                            users = users
                                .OrderBy(u => u.Rating)
                                .AsQueryable();
                            break;
                    }
                    break;
                case OrderDirectionType.Descending:
                    switch (property)
                    {
                        case UserProperty.Username:
                            users = users
                                .OrderByDescending(u => u.UserName)
                                .AsQueryable();
                            break;
                        case UserProperty.Email:
                            users = users
                                .OrderByDescending(u => u.Email)
                                .AsQueryable();
                            break;
                        case UserProperty.Raiting:
                            users = users
                                .OrderByDescending(u => u.Rating)
                                .AsQueryable();
                            break;
                    }
                    break;
            }

            switch (role)
            {
                case UserRoleType.Player:
                    return await this.mapper
                        .ProjectTo<TUserListingServiceModel>(
                            users.Where(u => !u.Roles.Any())
                            .Skip((page - 1) * UsersPageSize)
                            .Take(UsersPageSize))
                            .ToListAsync();
                case UserRoleType.Publisher:
                    return await this.mapper
                        .ProjectTo<TUserListingServiceModel>(
                            users
                            .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                            .Skip((page - 1) * UsersPageSize)
                            .Take(UsersPageSize))
                        .ToListAsync();
                default:
                    return null;
            }
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
