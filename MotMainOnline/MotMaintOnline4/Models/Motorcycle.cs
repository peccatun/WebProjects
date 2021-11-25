using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotMaintOnline4.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public DateTime ProductionDate { get; set; }

        public int StartKilometers { get; set; }

        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();
    }
}
