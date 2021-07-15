namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Publishers;
    using Services.Admin;
    using System.Threading.Tasks;

    public class PublishersController : AdminBaseController
    {
        private readonly IAdminUsersService adminUsers;
        private readonly UserManager<User> userManager;

        public PublishersController(
            IAdminUsersService adminUsersService,
            UserManager<User> userManager)
        {
            this.adminUsers = adminUsersService;
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePublisherFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await this.userManager.CreateAsync(new User
            {
                Email = formModel.Email,
                UserName = formModel.Username,

            }, formModel.Password);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index(int page = 1)
            => View(new PublisherListingViewModel
            {
                Publishers = await this.adminUsers.AllPublishersAsync(page),
                TotalPublishers = await this.adminUsers.CountAsync(),
                CurrentPage = page
            });
    }
}
