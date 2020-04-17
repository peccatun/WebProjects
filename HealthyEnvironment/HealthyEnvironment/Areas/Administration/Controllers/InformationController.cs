using HealthyEnvironment.Areas.Administration.Services;
using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class InformationController : Controller
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }

        public IActionResult AllInformation()
        {
            AllInformationViewModel model = new AllInformationViewModel
            {
                Information = this.informationService.GetAllInformation()
            };

            return this.View(model);
        }

        public IActionResult InformationDetails(string informationId)
        {
            return this.View();
        }
    }
}
