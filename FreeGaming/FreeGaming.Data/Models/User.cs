namespace FreeGaming.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Constants;

    public class User
    {
        public int Id { get; set; }

        [MaxLength(16)]
        [Required()]
        public string Username { get; set; }

        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        [MaxLength(128)]
        [Required]
        public string Password { get; set; }

        [MaxLength(StringMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(StringMaxLength)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Country? Country { get; set; }

        // Rating for playing enogh time.
        public int Rating { get; set; }

        public IEnumerable<UserGame> Games { get; set; } = new List<UserGame>();
    }
}
