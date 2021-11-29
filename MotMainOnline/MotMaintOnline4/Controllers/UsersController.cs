using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.Services.ApplicationUser;
using MotMaintOnline4.Services.Motorcycles;
using MotMaintOnline4.ViewModels.ApplicationUser;

namespace MotMaintOnline4.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IMotorcycleService motorcycleService;

        public UsersController(IApplicationUserService applicationUserService, IMotorcycleService motorcycleService)
        {
            this.applicationUserService = applicationUserService;
            this.motorcycleService = motorcycleService;
        }

        public IActionResult UserDetails(int id)
        {
            UserDetailsViewModel model = applicationUserService.UserDetails(id);
            model.Motorcycles = motorcycleService.UserMotorcycles(id);

            return View(model);
        }
    }
}
