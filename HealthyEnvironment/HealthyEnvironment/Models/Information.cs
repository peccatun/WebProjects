using System;

namespace HealthyEnvironment.Models
{
    public class Information
    {
        public Information()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public byte[] Image { get; set; }

        public string Content { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
