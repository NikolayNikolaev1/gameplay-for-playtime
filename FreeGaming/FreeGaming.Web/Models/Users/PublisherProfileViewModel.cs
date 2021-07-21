namespace FreeGaming.Web.Models.Users
{
    using Services.Models.Games;
    using Services.Models.Users;
    using System.Collections.Generic;

    // Look into Custom Model Binding
    // Documentaiont: https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-5.0
    public class PublisherProfileViewModel
    {
        public PublisherProfileServiceModel PublisherInfo { get; set; }

        public IEnumerable<GameListingServiceModel> GamesList { get; set; }
    }
}
