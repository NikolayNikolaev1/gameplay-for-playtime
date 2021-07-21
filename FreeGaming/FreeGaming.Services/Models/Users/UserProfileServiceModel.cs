namespace FreeGaming.Services.Models.Users
{
    using Data.Enums;
    using System;

    public class UserProfileServiceModel : BaseProfileServiceModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Country? Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Raiting { get; set; }
    }
}
