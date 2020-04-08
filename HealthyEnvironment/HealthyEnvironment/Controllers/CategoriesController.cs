using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
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
    }
}
