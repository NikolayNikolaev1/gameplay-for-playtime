namespace FreeGaming.Services.Implementaions
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly FreeGamingDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(FreeGamingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns profile service model, based on whats the generic user role type.
        /// </summary>
        /// <typeparam name="TUserProfileServiceModel">User role type</typeparam>
        /// <param name="id">User Id</param>
        /// <returns>Profile Service Model</returns>
        public async Task<TUserProfileServiceModel> ProfileAsync<TUserProfileServiceModel>(string id)
            where TUserProfileServiceModel : BaseProfileServiceModel, new()
            => await this.dbContext
            .Users
            .ProjectTo<TUserProfileServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
