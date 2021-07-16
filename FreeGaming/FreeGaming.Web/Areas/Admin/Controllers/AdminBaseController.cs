namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Admin;
    using Services.Enums;
    using System;

    using static Common.WebConstants.Roles;

    [Area("Admin")]
    [Authorize(Roles = Administrator)]
    public abstract class AdminBaseController<T> : Controller
        where T : AdminBaseController<T>
    {
        private IAdminUsersService adminUsers;

        protected IAdminUsersService AdminUsers => this.adminUsers ?? (this.adminUsers = HttpContext.RequestServices.GetService<IAdminUsersService>());

        protected OrderDirectionType GetOrderDirectionType(string order)
            => order.ToLower() == "ascending"
            ? OrderDirectionType.Ascending
            : OrderDirectionType.Descending;

        protected UserProperty GetUserProperty(string property)
        {
            UserProperty userProperty;

            if (string.IsNullOrEmpty(property))
            {
                // Default order: all properties ascending.
                userProperty = 0;
            }
            else
            {
                Enum.TryParse(property, out userProperty);
            }

            return userProperty;
        }
    }
}
