using System;
using System.Collections.Generic;

namespace HealthyEnvironment.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public IEnumerable<Information> Informations { get; set; } = new HashSet<Information>();

        public IEnumerable<Discussion> Discussions { get; set; } = new HashSet<Discussion>();
    }
}
