namespace FreeGaming.Web.Areas.Admin.Models.Publishers
{
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants.UserProperties;
    using static Common.WebConstants.ErrorMessages;

    public class CreatePublisherFormModel
    {
        [Required]
        [MaxLength(UserNameMaxLength, ErrorMessage = InvalidUserPropertyMaxLength)]
        [MinLength(UserNameMinLength, ErrorMessage = InvalidUserPropertyMinLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength, ErrorMessage = InvalidUserPropertyMaxLength)]
        [MinLength(EmailMinLength, ErrorMessage = InvalidUserPropertyMinLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength, ErrorMessage = InvalidUserPropertyMaxLength)]
        [MinLength(PasswordMinLength, ErrorMessage = InvalidUserPropertyMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
