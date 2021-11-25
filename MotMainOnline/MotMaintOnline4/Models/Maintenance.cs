using System;

namespace MotMaintOnline4.Models
{
    public class Maintenance
    {
        public int Id { get; set; }

        public bool IsDel { get; set; }

        public DateTime DateDone { get; set; }

        public int Kilometers { get; set; }

        public string Description { get; set; }

        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MaintenanceTypeId { get; set; }

        public virtual MaintenanceType MaintenanceType { get; set; }

        public int MotorcycleId { get; set; }

        public virtual Motorcycle Motorcycle { get; set; }
    }
}
