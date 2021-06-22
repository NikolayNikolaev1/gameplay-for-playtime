namespace FreeGaming.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Constants;

    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(StringMaxLength)]
        [Required]
        public string Name { get; set; }

        public GenreType Type { get; set; }

        public IEnumerable<GameGenre> Games { get; set; } = new List<GameGenre>();
    }
}
