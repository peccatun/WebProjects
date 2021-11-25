using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Models
{
    public class MaintenanceType
    {
        public int Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public virtual Maintenance Maintenance { get; set; }
    }
}
