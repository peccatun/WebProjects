using MotMaintOnline4.InputModels.Maintenances;
using MotMaintOnline4.ViewModels.Maintenance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.MaintenanceServ
{
    public interface IMaintenanceService
    {
        Task Create(MaintenanceInputModel inputModel);
    }
}
