namespace FreeGaming.Services.Admin.Implementaions
{
    using AutoMapper;
    using Data;
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

        public async Task<IEnumerable<AdminBaseUserListingServiceModel>> AllAsync(int page = 1, string userRole = null)
        {
            if (userRole == Roles.Publisher)
            {
                return await this.mapper
                    .ProjectTo<AdminPublisherListingServiceModel>(
                        this.dbContext
                        .Users
                        .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                        .Skip((page - 1) * UsersPageSize)
                        .Take(UsersPageSize))
                    .ToListAsync();
            }

            return await this.mapper
                .ProjectTo<AdminNormalUserListingServiceModel>(
                    this.dbContext
                    .Users
                    .Where(u => !u.Roles.Any())
                    .Skip((page - 1) * UsersPageSize)
                    .Take(UsersPageSize))
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminPublisherListingServiceModel>> AllPublishersAsync(int page = 1)
            => await this.mapper
            .ProjectTo<AdminPublisherListingServiceModel>(
                this.dbContext
                .Users
                .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                .Skip((page - 1) * UsersPageSize)
                .Take(UsersPageSize))
            .ToListAsync();

        public async Task<IEnumerable<AdminNormalUserListingServiceModel>> AllUsersAsync(int page = 1)
            => await this.mapper
            .ProjectTo<AdminNormalUserListingServiceModel>(
                this.dbContext
                .Users
                .Where(u => !u.Roles.Any())
                .Skip((page - 1) * UsersPageSize)
                .Take(UsersPageSize))
            .ToListAsync();

        public async Task<int> CountAsync(string userRole = null)
        {
            if (userRole == Roles.Publisher)
            {
                return await this.dbContext
                    .Users
                    .Where(u => u.Roles.Any(r => r.Role.Name == Roles.Publisher))
                    .CountAsync();
            }

            return await this.dbContext
                .Users
                .Where(u => !u.Roles.Any())
                .CountAsync();
        }
    }
}
