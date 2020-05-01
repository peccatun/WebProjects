using HealthyEnvironment.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.ViewModels.Informations
{
    public class CreateInfomationViewModel
    {
        [Required]
        [Display(Name = "About")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 4)]
        public string About { get; set; }

        [Required]
        [Display(Name = "Information content")]
        [StringLength(10000, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 20)]
        public string Content { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Add in category")]
        public string CategoryId { get; set; }

        [MaxLength(7)]
        [Display(Name = "Additional Images")]
        public IFormFile[] AdditionalImages { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
