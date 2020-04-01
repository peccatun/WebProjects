using System;

namespace HealthyEnvironment.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string InformationId { get; set; }

        public Information Information { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public bool IsDeleted { get; set; }
    }
}
