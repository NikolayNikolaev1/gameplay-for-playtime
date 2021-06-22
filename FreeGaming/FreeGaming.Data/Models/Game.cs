namespace FreeGaming.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Constants;

    public class Game
    {
        public int Id { get; set; }

        [MaxLength(StringMaxLength)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        [Range(RangeMinValue, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(RangeMinValue, double.MaxValue)]
        // Size in Gb.
        public double Size { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Url]
        public string TrailerUrl { get; set; }

        public int DeveloperId { get; set; }

        public Developer Developer { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public IEnumerable<GameGenre> Genres { get; set; } = new List<GameGenre>();
    }
}
