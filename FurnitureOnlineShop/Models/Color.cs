using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(50)]
        public string ColorName { get; set; }

        public virtual Product Product { get; set; }
    }
}
