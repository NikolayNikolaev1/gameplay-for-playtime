namespace FreeGaming.Services.Publisher
{
    using Data.Enums;
    using System;
    using System.Threading.Tasks;

    public interface IPublisherGamesService
    {
        Task AddAsync(
            string title,
            string description,
            decimal price,
            double size,
            DateTime releaseDate,
            byte[] image,
            GenreType genre,
            string trailerId,
            string developer,
            string publisherId);
    }
}
