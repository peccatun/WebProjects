using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.Dtos.MaintenanceTypes;
using MotMaintOnline4.Services.MaintenanceTypeServ;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotMaintOnline4.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        private readonly IMaintenanceTypeService maintenanceTypeService;

        public MaintenanceTypeController(IMaintenanceTypeService maintenanceTypeService)
        {
            this.maintenanceTypeService = maintenanceTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return StatusCode(400);
            }

            await maintenanceTypeService.Create(type);

            var maintenanceTypes = maintenanceTypeService.GetAll();

            return Ok(maintenanceTypes);
        }
    }
}
