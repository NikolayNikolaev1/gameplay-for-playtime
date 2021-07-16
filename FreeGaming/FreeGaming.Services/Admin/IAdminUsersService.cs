namespace FreeGaming.Services.Admin
{
    using Models;
    using Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUsersService
    {
        Task<IEnumerable<TUserListingServiceModel>> AllAsync<TUserListingServiceModel>(
            UserRoleType role,
            UserProperty property,
            OrderDirectionType orderDirection,
            int page = 1)
            where TUserListingServiceModel : AdminBaseListingServiceModel, new();

        Task<int> CountAsync(UserRoleType role);
    }
}
