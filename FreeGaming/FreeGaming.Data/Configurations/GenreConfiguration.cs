namespace FreeGaming.Data.Configurations
{
    using Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System.Collections.Generic;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> genre)
        {
            //genre
            //    .HasData(new Genre
            //    {
            //        Id = 1,
            //        Name = "First-Person Shooter",
            //        Type = GenreType.Action
            //    });
        }
    }
}
