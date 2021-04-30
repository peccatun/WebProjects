using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class SubCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsDel { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubCategoryName { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
