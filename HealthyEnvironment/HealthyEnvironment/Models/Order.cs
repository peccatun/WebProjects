using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();

        public DateTime OrderDate { get; set; }

        public bool IsActive { get; set; }
    }
}
