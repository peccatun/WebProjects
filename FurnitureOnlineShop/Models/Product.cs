using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        //Think about editing the string lenght when you update this model!!!

        [StringLength(500)]
        public string Description { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
    }
}
