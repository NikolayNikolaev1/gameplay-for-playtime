namespace FreeGaming.Services.Models.Users
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Linq;

    public class PublisherProfileServiceModel : BaseProfileServiceModel, IHaveCustomMapping
    {
        public int TotalGamesPublished { get; set; }

        public void ConfigureMapping(IProfileExpression profile)
            => profile
            .CreateMap<User, PublisherProfileServiceModel>()
            .ForMember(p => p.TotalGamesPublished,
                cfg => cfg.MapFrom(u => u.PublishedGames.Count()));
    }
}
