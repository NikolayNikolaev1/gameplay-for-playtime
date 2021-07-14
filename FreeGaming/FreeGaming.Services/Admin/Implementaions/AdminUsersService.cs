namespace FreeGaming.Services.Admin.Implementaions
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUsersService : IAdminUsersService
    {
        private readonly FreeGamingDbContext dbContext;

        public AdminUsersService(FreeGamingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AdminPublisherListingServiceModel>> AllPublishersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
