using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        public string ProductName { get; set; }

        //Think about editing the string lenght when you update this model!!!

        
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int ColorId { get; set; }

        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ProductImage ProductImage { get; set; }

        public virtual Color Color { get; set; }

    }
}
