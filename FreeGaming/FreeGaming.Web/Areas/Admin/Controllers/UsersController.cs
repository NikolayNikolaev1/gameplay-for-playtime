namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services.Admin;
    using Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController
    {
        private readonly IAdminUsersService adminUsers;

        public UsersController(IAdminUsersService adminUsers)
        {
            this.adminUsers = adminUsers;
        }

        public async Task<IActionResult> Index(int page = 1)
            => View(new UserListingViewModel
            {
                // TODO: Refactor this or just remove the whole abstract base controller logic...
                Users = (IEnumerable<AdminNormalUserListingServiceModel>)await this.adminUsers.AllAsync(page),
                TotalUsers = await this.adminUsers.CountAsync(),
                CurrentPage = page
            });
    }
}
