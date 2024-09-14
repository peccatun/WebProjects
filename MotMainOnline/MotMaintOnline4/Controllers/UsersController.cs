using Microsoft.AspNetCore.Mvc;
using MotMaintOnline4.Services.ApplicationUser;

namespace MotMaintOnline4.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApplicationUserService applicationUserService;

        public UsersController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        public IActionResult UserDetails(int id)
        {
            var viewModel = applicationUserService.UserDetails(id);

            return View(viewModel);
        }
    }
}
