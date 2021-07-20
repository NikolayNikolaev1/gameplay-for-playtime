namespace FreeGaming.Web.Areas.Publisher.Models.Games
{
    using Data.Enums;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants.GameProperties;
    using static Common.WebConstants.ErrorMessages;

    public class AddGameFormModel
    {
        [MaxLength(TitleMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(TitleMinLength, ErrorMessage = InvalidPropertyMinLength)]
        [Required]
        public string Title { get; set; }

        [MaxLength(DescriptionMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(DescriptionMinLength, ErrorMessage = InvalidPropertyMinLength)]
        [Required]
        public string Description { get; set; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Range(SizeMinValue, SizeMaxValue)]
        // Size in Gb.
        public double Size { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Tester")]
        public BufferedSingleFileUploadDb Image { get; set; }

        [Display(Name = "Trailer Video Id")]
        [StringLength(
            TrailerIdLength,
            MinimumLength = TrailerIdLength,
            ErrorMessage = InvalidGameTrailerIdLength)]
        [Required]
        public string TrailerId { get; set; }

        public GenreType Genre { get; set; }

        [MaxLength(DeveloperMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(DeveloperMinLength, ErrorMessage = InvalidPropertyMinLength)]
        [Required]
        public string Developer { get; set; }
    }
}
