namespace FreeGaming.Web.Areas.Admin.Models.Publishers
{
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants.UserProperties;

    public class CreatePublisherFormModel
    {
        [Required]
        [MaxLength(UserNameMaxLength)]
        [MinLength(UserNameMinLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        [MinLength(EmailMinLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        [MinLength(PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
