using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.InputModels.Motorcycles;
using MotMaintOnline4.Services.MaintenanceServ;
using MotMaintOnline4.Services.MaintenanceTypeServ;
using MotMaintOnline4.Services.Motorcycles;
using MotMaintOnline4.ViewModels.Motorcycles;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Controllers
{
    public class MotorcyclesController : Controller
    {
        private readonly IMotorcycleService motorcycleService;
        private readonly IMaintenanceService maintenanceService;
        private readonly IMaintenanceTypeService maintenanceTypeService;

        public MotorcyclesController(IMotorcycleService motorcycleService, IMaintenanceService maintenanceService, IMaintenanceTypeService maintenanceTypeService)
        {
            this.motorcycleService = motorcycleService;
            this.maintenanceService = maintenanceService;
            this.maintenanceTypeService = maintenanceTypeService;
        }

        public async Task<IActionResult> Create([Bind(Prefix = "InputModel")]MotorcycleInputModel inputModel)
        {
            int userId = inputModel.ApplicationUserId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("UserDetails", "Users", new { id = userId });
            }

            await motorcycleService.Create(inputModel);

            return RedirectToAction("UserDetails" , "Users", new { id = userId });
        }

        public async Task<IActionResult> Edit([Bind(Prefix = "InputModel")]MotorcycleInputModel inputModel)
        {
            int userId = inputModel.ApplicationUserId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("UserDetails", "Users", new { id = userId });
            }

            await motorcycleService.Edit(inputModel);

            return RedirectToAction("UserDetails", "Users", new { id = userId });
        }

        public async Task<IActionResult> Delete(int id, int userId)
        {
            await motorcycleService.Delete(id);

            return RedirectToAction("UserDetails", "Users", new { id = userId});
        }

        [HttpGet]
        public IActionResult Details(int id, int maintenanceTypeId = -1)
        {
            DetailsViewModel details = motorcycleService.Details(id);
            details.Maintenances = maintenanceService.GetMaintenances(id);
            details.MaintenanceTypes = maintenanceTypeService.GetAll();

            if (maintenanceTypeId > 0)
            {
                details.Maintenances = details.Maintenances.Where(m => m.MaintenanceTypeId == maintenanceTypeId).ToList();
            }


            return View(details);
        }
    }
}
