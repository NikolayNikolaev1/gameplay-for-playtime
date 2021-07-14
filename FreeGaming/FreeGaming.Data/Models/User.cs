namespace FreeGaming.Data.Models
{
    using Enums;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants;

    public class User : IdentityUser
    {
        [MaxLength(StringMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(StringMaxLength)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Country? Country { get; set; }

        public byte[] Image { get; set; }

        // Rating for playing enogh time.
        public int? Rating { get; set; }

        public IEnumerable<UserGame> Games { get; set; } = new List<UserGame>();

        public IEnumerable<Game> PublishedGames { get; set; } = new List<Game>();
    }
}
