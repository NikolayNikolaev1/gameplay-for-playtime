namespace FreeGaming.Services
{
    using System.Threading.Tasks;

    public interface IGameService
    {
        Task<bool> ContainsAsync(string title);
    }
}
