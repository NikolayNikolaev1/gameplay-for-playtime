namespace FreeGaming.Web.Areas.Publisher.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
