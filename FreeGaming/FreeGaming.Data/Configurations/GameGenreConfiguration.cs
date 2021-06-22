namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> gameGenre)
        {
            gameGenre
                .HasKey(gg => new { gg.GameId, gg.GenreId });

            gameGenre
                .HasOne(gg => gg.Game)
                .WithMany(g => g.Genres)
                .HasForeignKey(gg => gg.GameId);

            gameGenre
                .HasOne(gg => gg.Genre)
                .WithMany(g => g.Games)
                .HasForeignKey(gg => gg.GenreId);
        }
    }
}
