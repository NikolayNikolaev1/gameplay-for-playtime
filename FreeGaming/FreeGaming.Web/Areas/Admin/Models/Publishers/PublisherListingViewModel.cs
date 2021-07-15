namespace FreeGaming.Web.Areas.Admin.Models.Publishers
{
    using Services.Admin.Models;
    using System;
    using System.Collections.Generic;

    using static Common.WebConstants;

    public class PublisherListingViewModel
    {
        public IEnumerable<AdminPublisherListingServiceModel> Publishers { get; set; }

        public int TotalPublishers { get; set; }

        public int TotalPages 
            => (int)Math.Ceiling((double)this.TotalPublishers / UsersPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage 
            => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage 
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}
