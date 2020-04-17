using HealthyEnvironment.Areas.Administration.Services;
using HealthyEnvironment.Areas.Administration.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles ="Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult AllCategories()
        {
            AllNotApprovedCategoriesViewModel model = new AllNotApprovedCategoriesViewModel
            {
                Categories = categoriesService.GetAllCategories(),
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult CategoryDetails(string categoryId)
        {
            CategoryDetailsViewModel model = categoriesService.GetCategoryDetails(categoryId);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDetailsViewModel model)
        {
            await categoriesService.UpdateCategoryAsync(model);

            return this.Redirect("/Categories");
        }
    }
}
