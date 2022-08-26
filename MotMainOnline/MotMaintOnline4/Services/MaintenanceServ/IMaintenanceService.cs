using MotMaintOnline4.InputModels.Maintenances;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.MaintenanceServ
{
    public interface IMaintenanceService
    {
        Task Create(MaintenanceInputModel inputModel);
    }
}
