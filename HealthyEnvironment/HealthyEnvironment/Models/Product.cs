using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Discription")]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 10)]
        public string Discription { get; set; }

        //TODO: Decide what will you do with ProductCategory

        [Required]
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public bool IsDeleted { get; set; }
    }
}
