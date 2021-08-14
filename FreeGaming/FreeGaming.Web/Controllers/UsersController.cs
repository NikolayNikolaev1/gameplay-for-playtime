namespace FreeGaming.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services;
    using Services.Models.Users;
    using System.Threading.Tasks;

    using static Common.WebConstants;

    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly IGameService games;
        private readonly UserManager<User> userManager;

        public UsersController(
            IUserService users,
            IGameService games,
            UserManager<User> userManager)
        {
            this.users = users;
            this.games = games;
            this.userManager = userManager;
        }

        [Route("/profile/{userName}")]
        public async Task<IActionResult> Profile(string userName)
        {
            User user = await this.userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            string userId = user.Id;
            bool isPublisher = await this.userManager.IsInRoleAsync(user, Roles.Publisher);
            // Return publisher page for publisher or user profile for users.
            return isPublisher
                ? View("PublisherProfile", new PublisherProfileViewModel
                {
                    PublisherInfo = await this.users.ProfileAsync<PublisherProfileServiceModel>(userId),
                    GamesList = await this.games.AllAsync(userId)
                })
                : View("UserProfile", new UserProfileViewModel
                {
                    UserInfo = await this.users.ProfileAsync<UserProfileServiceModel>(userId),
                    GamesList = await this.games.AllAsync(userId)
                });
        }
    }
}
