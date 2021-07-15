namespace FreeGaming.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> developer)
        {
            //developer
            //    .HasData(new Developer
            //    { 
            //        Id = 1,
            //        Name = "Blizzard Entertainment"
            //    });
        }
    }
}
