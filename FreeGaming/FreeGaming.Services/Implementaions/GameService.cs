namespace FreeGaming.Services.Implementaions
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GameService : IGameService
    {
        private readonly FreeGamingDbContext dbContext;

        public GameService(FreeGamingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ContainsAsync(string title)
            => await this.dbContext
            .Games
            .AnyAsync(g => g.Title == title);
    }
}
