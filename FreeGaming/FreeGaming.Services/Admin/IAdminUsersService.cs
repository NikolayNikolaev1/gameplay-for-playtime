namespace FreeGaming.Services.Admin
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUsersService
    {
        Task<IEnumerable<AdminPublisherListingServiceModel>> AllPublishersAsync(int page = 1);

        Task<IEnumerable<AdminNormalUserListingServiceModel>> AllUsersAsync(int page = 1);

        Task<IEnumerable<AdminBaseUserListingServiceModel>> AllAsync( int page = 1, string userRole = null);

        Task<int> CountAsync(string userRole = null);
    }
}
