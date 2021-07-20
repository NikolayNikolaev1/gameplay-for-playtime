namespace FreeGaming.Web.Areas.Admin.Models.Publishers
{
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstants.UserProperties;
    using static Common.WebConstants.ErrorMessages;

    public class CreatePublisherFormModel
    {
        [Required]
        [MaxLength(UserNameMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(UserNameMinLength, ErrorMessage = InvalidPropertyMinLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(EmailMinLength, ErrorMessage = InvalidPropertyMinLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength, ErrorMessage = InvalidPropertyMaxLength)]
        [MinLength(PasswordMinLength, ErrorMessage = InvalidPropertyMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = PasswordsMissmatch)]
        public string ConfirmPassword { get; set; }
    }
}
