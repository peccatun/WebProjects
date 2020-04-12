using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Upload Image")]
        public IFormFile Image { get; set; }
    }
}
