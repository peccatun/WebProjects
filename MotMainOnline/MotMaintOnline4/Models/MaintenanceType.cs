using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotMaintOnline4.Models
{
    public class MaintenanceType
    {
        public int Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public virtual IEnumerable<Maintenance> Maintenances { get; set; }
    }
}
