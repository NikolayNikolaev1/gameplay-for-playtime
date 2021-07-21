namespace FreeGaming.Services.Models.Users
{
    using Data.Models;
    using Infrastructure.Mapping;

    public abstract class BaseProfileServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public byte[] Image { get; set; }
    }
}
