namespace FreeGaming.Services.Admin.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }
    }
}
