using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyEnvironment.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IMediaService mediaService;

        public CategoriesController(ICategoriesService categoriesService, IMediaService mediaService)
        {
            this.categoriesService = categoriesService;
            this.mediaService = mediaService;
        }

        [HttpGet("/Categories")]
        public IActionResult CategoriesHome()
        {
            AllCategoriesViewModel categories = new AllCategoriesViewModel
            {
                Categories = this.categoriesService.GetAllCategories()
            };
            return this.View(categories);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await categoriesService.CreateCategoryAsync(model);

            return this.Redirect("/");
        }
    }
}
