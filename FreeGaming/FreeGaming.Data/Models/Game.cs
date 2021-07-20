namespace FreeGaming.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants.GameProperties;

    public class Game
    {
        public int Id { get; set; }

        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        [Required]
        public string Title { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        [Required]
        public string Description { get; set; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Range(SizeMinValue, SizeMaxValue)]
        // Size in Gb.
        public double Size { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte[] Image { get; set; }

        [StringLength(TrailerIdLength)]
        [Required]
        public string TrailerId { get; set; }

        [MaxLength(DeveloperMaxLength)]
        [MinLength(DeveloperMinLength)]
        [Required]
        public string Developer { get; set; }

        public GenreType Genre { get; set; }

        public string PublisherId { get; set; }

        public User Publisher { get; set; }

        public IEnumerable<UserGame> Users { get; set; } = new List<UserGame>();
    }
}
