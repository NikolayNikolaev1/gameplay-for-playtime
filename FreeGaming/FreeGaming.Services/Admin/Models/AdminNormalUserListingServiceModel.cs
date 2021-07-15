namespace FreeGaming.Services.Admin.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminNormalUserListingServiceModel : AdminBaseUserListingServiceModel, IMapFrom<User>
    {
        public int Rating { get; set; }
    }
}
