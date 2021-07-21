namespace FreeGaming.Services.Models.Games
{
    using Data.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class GameListingServiceModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public byte[] Image { get; set; }

        public string Developer { get; set; }

        public GenreType Genre { get; set; }
    }
}
