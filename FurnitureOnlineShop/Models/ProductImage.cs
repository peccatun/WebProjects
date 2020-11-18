using System;

namespace FurnitureOnlineShop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedON { get; set; }

        public byte[] ImageBytes { get; set; }

        public bool IsPrimaryImage { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
