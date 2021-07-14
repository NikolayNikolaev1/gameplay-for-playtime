namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using FreeGaming.Data.Models;
    using FreeGaming.Services.Admin;
    using FreeGaming.Web.Areas.Admin.Models.Publishers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PublishersController : AdminBaseController
    {
        private readonly IAdminUsersService adminUsersService;
        private readonly UserManager<User> userManager;

        public PublishersController(
            IAdminUsersService adminUsersService,
            UserManager<User> userManager)
        {
            this.adminUsersService = adminUsersService;
            this.userManager = userManager;
        }
        public IActionResult All()
        {
            return null;
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

            return RedirectToAction(nameof(All));
        }
    }
}
