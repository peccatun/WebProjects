using HealthyEnvironment.ViewModels.Categories;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HealthyEnvironment.Areas.Administration.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50 , ErrorMessage = "Product {0} must be between {2} and {1} characters.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Upload image head picture")]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Discription")]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 10)]
        public string Discription { get; set; }

        [Required]
        [Display(Name = "Product in category")]
        public string CategoryId { get; set; }

        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Display(Name = "Product quantity")]
        public int Count { get; set; }

        [MaxLength(8)]
        [Display(Name = "Additional Images")]
        public IFormFile[] AdditionalImages { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
