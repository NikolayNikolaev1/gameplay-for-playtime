﻿namespace FreeGaming.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services;
    using Services.Models.Users;
    using System.Linq;
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

        [Route("/profile/{userId}")]
        public async Task<IActionResult> Profile(string userId)
        {
            User user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            bool isPublisher = user.Roles.Any(r => r.Role.Name.Equals(Roles.Publisher));
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