using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotMaintOnline4.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsDel { get; set; }

        public virtual IEnumerable<Motorcycle> Motorcycles { get; set; } = new HashSet<Motorcycle>();

        public virtual IEnumerable<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();
    }
}
