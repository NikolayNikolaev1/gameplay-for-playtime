namespace FreeGaming.Services.Admin.Models
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class AdminPublisherListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        //public IEnumerable<UserRole> Roles { get; set; }
    }
}
