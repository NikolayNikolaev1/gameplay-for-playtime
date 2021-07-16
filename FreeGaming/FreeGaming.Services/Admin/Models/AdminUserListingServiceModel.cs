namespace FreeGaming.Services.Admin.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUserListingServiceModel : AdminBaseListingServiceModel, IMapFrom<User>
    {
        public int Rating { get; set; }
    }
}
