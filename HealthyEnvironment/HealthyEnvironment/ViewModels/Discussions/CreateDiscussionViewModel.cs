using HealthyEnvironment.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class CreateDiscussionViewModel
    {
        [Required]
        [Display(Name = "About")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        public string About { get; set; }

        [Required]
        [Display(Name = "Additional Info")]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 1)]
        public string AdditionalInfo { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        [Display(Name = "UploadImage")]
        public IFormFile Image { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
