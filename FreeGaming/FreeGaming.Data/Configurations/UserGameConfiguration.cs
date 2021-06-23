namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserGameConfiguration : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> userGame)
        {
            userGame
                .HasKey(ug => new { ug.UserId, ug.GameId });

            userGame
                .HasOne(ug => ug.User)
                .WithMany(u => u.Games)
                .HasForeignKey(ug => ug.UserId);

            userGame
                .HasOne(ug => ug.Game)
                .WithMany(g => g.Users)
                .HasForeignKey(ug => ug.GameId);
        }
    }
}
