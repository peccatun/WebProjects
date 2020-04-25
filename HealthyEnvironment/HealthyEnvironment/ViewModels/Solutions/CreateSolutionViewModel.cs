using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.ViewModels.Solutions
{
    public class CreateSolutionViewModel
    {
        [Required]
        public string Content { get; set; }

        [Display(Name = "Upload image(optional)")]
        public IFormFile Image { get; set; }

        public string DiscussionId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
