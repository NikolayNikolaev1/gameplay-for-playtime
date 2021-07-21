namespace FreeGaming.Services.Implementaions
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Games;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Common.WebConstants;

    public class GameService : IGameService
    {
        private readonly FreeGamingDbContext dbContext;
        private readonly IMapper mapper;

        public GameService(FreeGamingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // Gets all games or user's games or publisher's games based on userId.
        public async Task<IEnumerable<GameListingServiceModel>> AllAsync(string userId = null, int page = 1)
        {
            var games = this.dbContext
                  .Games
                  .AsQueryable();

            games = userId != null
                ? games
                .Where(g => g.Users.Any(
                    // There can not be the same userId and publisherId in one game.
                    u => u.UserId == userId) ||
                    g.PublisherId == userId)
                .AsQueryable()
                : games.AsQueryable();
            
            return await games
                .ProjectTo<GameListingServiceModel>(this.mapper.ConfigurationProvider)
                .Skip((page - 1) * GamesPageSize)
                .Take(GamesPageSize)
                .ToListAsync();
        }

        public async Task<bool> ContainsAsync(string title)
            => await this.dbContext
            .Games
            .AnyAsync(g => g.Title == title);
    }
}
