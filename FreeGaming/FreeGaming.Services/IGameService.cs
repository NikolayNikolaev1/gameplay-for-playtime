namespace FreeGaming.Services
{
    using Models.Games;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameService
    {
        Task<IEnumerable<GameListingServiceModel>> AllAsync(string userId = null, int page = 1);

        Task<bool> ContainsAsync(string title);
    }
}
