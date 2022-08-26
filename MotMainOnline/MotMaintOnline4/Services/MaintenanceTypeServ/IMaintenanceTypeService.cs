using MotMaintOnline4.Dtos.MaintenanceTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.MaintenanceTypeServ
{
    public interface IMaintenanceTypeService
    {
        Task Create(string type);

        IEnumerable<MaintenanceTypeDto> GetAll();


    }
}
