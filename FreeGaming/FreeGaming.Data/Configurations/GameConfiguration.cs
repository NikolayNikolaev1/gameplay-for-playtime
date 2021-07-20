namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System;
    using System.Collections.Generic;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game
                .HasOne(g => g.Publisher)
                .WithMany(d => d.PublishedGames)
                .HasForeignKey(g => g.PublisherId);

            //game
            //    .HasData(new Game
            //    {
            //        Id = 1,
            //        Title = "Overwatch",
            //        Description = @"Overwatch is a 2016 team-based multiplayer first-person shooter developed and published by Blizzard Entertainment. Described as a hero shooter, Overwatch assigns players into two teams of six, with each player selecting from a large roster of characters, known as heroes, with unique abilities. Teams work to complete map-specific objectives within a limited period of time. Blizzard has added new characters, maps, and game modes post-release, all free of charge, with the only additional cost to players being optional loot boxes to purchase cosmetic items. It was released for PlayStation 4, Xbox One, and Windows in May 2016 and Nintendo Switch in October 2019. An optimized performance patch for the Xbox Series X and Series S was released in March 2021. Cross-platform play was supported across all platforms by June 2021.",
            //        Price = 19.99m,
            //        Size = 43,
            //        ReleaseDate = new DateTime(2016, 5, 24),
            //        TrailerId = "FqnKB22pOC0",
            //        DeveloperId = 1,
            //        PublisherId = "b74ddd14-6340-4840-95c2-db12554843e5"
            //    });
        }
    }
}
