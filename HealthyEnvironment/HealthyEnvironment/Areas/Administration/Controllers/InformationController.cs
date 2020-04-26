using HealthyEnvironment.Areas.Administration.Services;
using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class InformationController : Controller
    {
        private readonly IInformationServiceAdmin informationService;

        public InformationController(IInformationServiceAdmin informationService)
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
            InformationDetailsViewModel model = this.informationService.GetInformationById(informationId);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InformationDetails(UpdateInformationViewModel model)
        {
            await this.informationService.UpdateInformation(model);
            return this.Redirect("/Information");
        }
    }
}
