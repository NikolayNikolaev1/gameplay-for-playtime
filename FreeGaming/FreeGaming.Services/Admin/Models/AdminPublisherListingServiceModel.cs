﻿namespace FreeGaming.Services.Admin.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminPublisherListingServiceModel : AdminBaseListingServiceModel, IMapFrom<User>
    {
    }
}
