namespace FreeGaming.Web.Areas.Publisher.Controllers
{
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Games;
    using Services;
    using Services.Publisher;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using static Common.GlobalConstants.ImageFile;
    using static Common.WebConstants;

    [Area("Publisher")]
    [Authorize(Roles = Roles.Publisher)]
    public class GamesController : Controller
    {
        private readonly IPublisherGamesService publisherGames;
        private readonly IGameService games;
        private readonly UserManager<User> userManager;

        public GamesController(
            IPublisherGamesService publisherGames,
            IGameService games,
            UserManager<User> userManager)
        {
            this.publisherGames = publisherGames;
            this.games = games;
            this.userManager = userManager;
        }

        public IActionResult Add() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(AddGameFormModel formModel)
        {
            string gameTitle = formModel.Title;
            bool titleExists = await this.games.ContainsAsync(gameTitle);

            if (titleExists)
            {
                ModelState.AddModelError(nameof(formModel.Title),
                    string.Format(ErrorMessages.GameTitleExists, gameTitle));
                return View(formModel);
            }

            byte[] gameImage;
            // Upload small image file with buffered model binding to database.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var uploadedFile = formModel.Image.FormFile;
                string uploadedFileName = uploadedFile.FileName;
                string imageModelKey = nameof(formModel.Image);

                if (!this.FileExtensionValidation(uploadedFileName))
                {
                    ModelState.AddModelError(imageModelKey, ErrorMessages.InvalidImageFileExtension);
                    return View(formModel);
                }

                if (!this.FileSignatureValidation(uploadedFileName, uploadedFile.OpenReadStream()))
                {
                    ModelState.AddModelError(imageModelKey, ErrorMessages.InvalidImageFileSignature);
                    return View(formModel);
                }

                await uploadedFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < MaxImageSize)
                {
                    gameImage = memoryStream.ToArray();
                }
                else
                {
                    ModelState.AddModelError(imageModelKey, ErrorMessages.InvalidImageFileLength);
                    return View(formModel);
                }
            }

            await this.publisherGames.AddAsync(
                gameTitle,
                formModel.Description,
                formModel.Price,
                formModel.Size,
                formModel.ReleaseDate,
                gameImage,
                formModel.Genre,
                formModel.TrailerId,
                formModel.Developer,
                this.userManager.GetUserId(User));

            return Redirect("/");
        }

        private bool FileExtensionValidation(string uploadedFileName)
        {
            string ext = this.GetFileExtension(uploadedFileName);

            return !string.IsNullOrEmpty(ext) &&
                PermittedExtensions.Contains(ext);
        }

        private bool FileSignatureValidation(string uploadedFileName, Stream uploadedFileData)
        {
            string ext = this.GetFileExtension(uploadedFileName);

            using (BinaryReader reader = new BinaryReader(uploadedFileData))
            {
                var signatures = ValidSignatures[ext];
                byte[] headerBytes = reader
                    .ReadBytes(signatures.Max(m => m.Length));

                return signatures.Any(
                    signature => headerBytes
                    .Take(signature.Length)
                    .SequenceEqual(signature));
            }
        }

        private string GetFileExtension(string uploadedFileName)
            => Path
            .GetExtension(uploadedFileName)
            .ToLowerInvariant();
    }
}
