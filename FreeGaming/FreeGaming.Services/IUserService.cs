namespace FreeGaming.Services
{
    using Models.Users;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<TUserProfileServiceModel> ProfileAsync<TUserProfileServiceModel>(string id)
            where TUserProfileServiceModel : BaseProfileServiceModel, new();
    }
}
