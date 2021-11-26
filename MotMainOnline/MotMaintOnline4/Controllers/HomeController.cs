using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotMaintOnline4.InputModels.ApplicationUser;
using MotMaintOnline4.Models;
using MotMaintOnline4.Services.ApplicationUser;
using MotMaintOnline4.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUserService applicationUserService;

        public HomeController(ILogger<HomeController> logger, IApplicationUserService applicationUserService)
        {
            _logger = logger;
            this.applicationUserService = applicationUserService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                ApplicationUsers = applicationUserService.GetApplicationUsers(),
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([Bind(Prefix = "UserInputModel")]ApplicationUserInputModel inputModel)
        {
            await applicationUserService.Create(inputModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await applicationUserService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
