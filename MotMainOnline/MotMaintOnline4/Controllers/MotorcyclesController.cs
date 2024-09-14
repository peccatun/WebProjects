using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.InputModels.Motorcycles;
using MotMaintOnline4.Services.MaintenanceServ;
using MotMaintOnline4.Services.MaintenanceTypeServ;
using MotMaintOnline4.Services.Motorcycles;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Controllers
{
    public class MotorcyclesController : Controller
    {
        private readonly IMotorcycleService motorcycleService;

        public MotorcyclesController(
            IMotorcycleService motorcycleService)
        {
            this.motorcycleService = motorcycleService;;
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
            var details = motorcycleService.Details(id);

            if (maintenanceTypeId > 0)
            {
                details.Maintenances = details
                    .Maintenances
                    .Where(m => m.MaintenanceTypeId == maintenanceTypeId)
                    .ToList();
            }

            return View(details);
        }
    }
}
