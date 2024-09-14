using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.InputModels.Maintenances;
using MotMaintOnline4.Services.MaintenanceServ;
using MotMaintOnline4.Services.MaintenanceTypeServ;
using MotMaintOnline4.Services.Motorcycles;
using System.Threading.Tasks;

namespace MotMaintOnline4.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IMaintenanceTypeService maintenanceTypeService;
        private readonly IMaintenanceService maintenanceService;
        private readonly IMotorcycleService motorcycleService;

        public MaintenanceController(
            IMaintenanceTypeService maintenanceTypeService, 
            IMotorcycleService motorcycleService, 
            IMaintenanceService maintenanceService)
        {
            this.maintenanceTypeService = maintenanceTypeService;
            this.maintenanceService = maintenanceService;
            this.motorcycleService = motorcycleService;
        }

        [HttpGet]
        public IActionResult Create(int motorcycleId)
        {
            var inputModel = new MaintenanceInputModel
            {
                MaintenanceTypes = maintenanceTypeService.GetAll(),
                ApplicationUserId = motorcycleService.GetMotorcycleUserId(motorcycleId),
                MotorcycleId = motorcycleId,
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaintenanceInputModel inputModel) 
        {
            await maintenanceService.Create(inputModel);

            return RedirectToAction("Details", "Motorcycles", new { id = inputModel.MotorcycleId });
        }
    }
}
