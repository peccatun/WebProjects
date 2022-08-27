using MotMaintOnline4.ViewModels.Maintenance;
using MotMaintOnline4.Dtos.MaintenanceTypes;
using System.Collections.Generic;

namespace MotMaintOnline4.ViewModels.Motorcycles
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Kilometers { get; set; }

        public string ProductionDate { get; set; }

        public IEnumerable<MaintenanceViewModel> Maintenances { get; set; }

        public IEnumerable<MaintenanceTypeDto> MaintenanceTypes { get; set; }
    }
}
