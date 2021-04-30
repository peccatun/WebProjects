using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryImageId { get; set; }

        public virtual CategoryImage CategoryImage { get; set; }

        public virtual IEnumerable<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
    }
}
