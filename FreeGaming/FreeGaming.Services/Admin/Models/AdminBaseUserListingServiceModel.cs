namespace FreeGaming.Services.Admin.Models
{
    public abstract class AdminBaseUserListingServiceModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
