namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Publishers;
    using Services.Admin.Models;
    using Services.Enums;
    using System.Threading.Tasks;

    using static Common.WebConstants;

    public class PublishersController : AdminBaseController<PublishersController>
    {
        private readonly UserManager<User> userManager;

        public PublishersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(CreatePublisherFormModel formModel)
        {
            User publisher = new User
            {
                Email = formModel.Email,
                UserName = formModel.Username,
            };

            await this.userManager.CreateAsync(publisher, formModel.Password);
            await this.userManager.AddToRoleAsync(publisher, Roles.Publisher);

            return RedirectToAction(nameof(Index));
        }

        [Route("/admin/publishers/{property?}/{order?}/{page?}")]
        public async Task<IActionResult> Index(
            string property = null, string order = "ascending", int page = 1)
            => View(new PublisherListingViewModel
            {
                Publishers = await base.AdminUsers.AllAsync<AdminPublisherListingServiceModel>(
                    UserRoleType.Publisher,
                    base.GetUserProperty(property),
                    base.GetOrderDirectionType(order),
                    page),
                TotalPublishers = await base.AdminUsers.CountAsync(UserRoleType.Publisher),
                CurrentPage = page,
                OrderDirection = base.GetOrderDirectionType(order)
            });
    }
}
