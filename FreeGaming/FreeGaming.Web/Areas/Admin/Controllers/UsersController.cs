namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services.Admin.Models;
    using Services.Enums;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController<UsersController>
    {
        [Route("/admin/users/{property?}/{order?}/{page?}")]
        public async Task<IActionResult> Index(
            string property = null, string order = "ascending", int page = 1)
            => View(new UserListingViewModel
            {
                Users = await base.AdminUsers.AllAsync<AdminUserListingServiceModel>(
                    UserRoleType.Player,
                    base.GetUserProperty(property),
                    base.GetOrderDirectionType(order),
                    page),
                TotalUsers = await base.AdminUsers.CountAsync(UserRoleType.Publisher),
                CurrentPage = page,
                OrderDirection = base.GetOrderDirectionType(order)
            });
    }
}
