namespace FreeGaming.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants;

    public class Developer
    {
        public int Id { get; set; }

        [MaxLength(StringMaxLength)]
        [Required]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}
