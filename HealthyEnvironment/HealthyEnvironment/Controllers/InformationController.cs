using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Information;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Informations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyEnvironment.Controllers
{
    public class InformationController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IInformationService informationService;

        public InformationController(
            ICategoriesService categoriesService,
            IInformationService informationService)
        {
            this.categoriesService = categoriesService;
            this.informationService = informationService;
        }

        [HttpGet("/Information")]
        public IActionResult InformationHome()
        {
            InformationCategoriesViewModel model = new InformationCategoriesViewModel
            {
                informationCategories = informationService.GetInformationCategories(),
            };

            return this.View(model);
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateInfomationViewModel model)
        {
            string applicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.informationService.Create(model, applicationUserId);

            return this.Redirect("/Information");
        }
    }
}
