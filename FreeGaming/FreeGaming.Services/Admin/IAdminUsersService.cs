namespace FreeGaming.Services.Admin
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUsersService
    {
        Task<IEnumerable<AdminPublisherListingServiceModel>> AllPublishersAsync();

        Task<IEnumerable<AdminUserListingServiceModel>> AllUsersAsync();
    }
}
