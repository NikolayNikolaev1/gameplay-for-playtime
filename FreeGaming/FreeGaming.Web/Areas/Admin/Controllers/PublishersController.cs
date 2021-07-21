namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Publishers;
    using Services.Admin.Models;
    using Services.Enums;
    using System;
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
            string publisherUsername = formModel.Username;
            string publisherEmail = formModel.Email;

            if (await this.userManager.FindByNameAsync(publisherUsername) != null)
            {
                ModelState.AddModelError(nameof(formModel.Username),
                    string.Format(ErrorMessages.PublisherUsernameExists, publisherUsername));
                return View(formModel);
            }

            if (await this.userManager.FindByEmailAsync(publisherEmail) != null)
            {
                ModelState.AddModelError(nameof(formModel.Email),
                    string.Format(ErrorMessages.PublisherEmailExists, publisherEmail));
                return View(formModel);
            }

            User publisher = new User
            {
                Email = formModel.Email,
                UserName = formModel.Username,
                RegistrationDate = DateTime.UtcNow
            };

            IdentityResult userResult = await this.userManager.CreateAsync(publisher, formModel.Password);
            IdentityResult roleResult = await this.userManager.AddToRoleAsync(publisher, Roles.Publisher);

            if (!userResult.Succeeded || !roleResult.Succeeded)
            {
                return View(formModel);
            }

            TempData.AddSuccessMessage(SuccessMessages.PublisherCreation);

            return RedirectToAction(nameof(Index));
        }

        [Route("/admin/publishers/{property?}/{order?}/{page?}", Order = 2)]
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
