using MotMaintOnline4.Dtos.MaintenanceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.InputModels.Maintenances
{
    public class MaintenanceInputModel
    {
        public DateTime DateDone { get; set; }

        public int Kilometers { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ApplicationUserId { get; set; }

        public int MaintenanceTypeId { get; set; }

        public int MotorcycleId { get; set; }

        public IEnumerable<MaintenanceTypeDto> MaintenanceTypes { get; set; }
    }
}
