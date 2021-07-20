namespace FreeGaming.Services.Publisher.Implementations
{
    using Data.Enums;
    using FreeGaming.Data;
    using FreeGaming.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class PublisherGamesService : IPublisherGamesService
    {
        private readonly FreeGamingDbContext dbContext;

        public PublisherGamesService(FreeGamingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(
            string title,
            string description,
            decimal price,
            double size,
            DateTime releaseDate,
            byte[] image,
            GenreType genre,
            string trailerId,
            string developer,
            string publisherId)
        {
            await this.dbContext
                .AddAsync(new Game
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Size = size,
                    ReleaseDate = releaseDate,
                    Image = image,
                    Genre = genre,
                    TrailerId = trailerId,
                    Developer = developer,
                    PublisherId = publisherId
                });

            await dbContext.SaveChangesAsync();
        }
    }
}
