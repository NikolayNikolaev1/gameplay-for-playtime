namespace FreeGaming.Web.Areas.Admin.Models.Users
{
    using Services.Admin.Models;
    using Services.Enums;
    using System;
    using System.Collections.Generic;

    using static Common.WebConstants;

    public class UserListingViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public int TotalUsers { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)this.TotalUsers / UsersPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;

        public OrderDirectionType OrderDirection { get; set; }
    }
}
