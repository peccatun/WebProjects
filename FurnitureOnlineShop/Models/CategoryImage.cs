using System;

namespace FurnitureOnlineShop.Models
{
    public class CategoryImage
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte[] ImageBytes { get; set; }

        public virtual Category Category { get; set; }
    }
}
