using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Information;
using HealthyEnvironment.ViewModels.Informations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class InformationController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IInformationService informationService;

        public InformationController(ICategoriesService categoriesService, IInformationService informationService)
        {
            this.categoriesService = categoriesService;
            this.informationService = informationService;
        }

        [HttpGet("/Information")]
        public IActionResult InformationHome()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = categoriesService.GetCategoryNameInfo();
            CreateInfomationViewModel model = new CreateInfomationViewModel
            {
                Categories = categories,
            };

            return this.View(model);
        }
    }
}
