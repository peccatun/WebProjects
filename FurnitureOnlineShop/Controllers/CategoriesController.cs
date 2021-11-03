using FurnitureOnlineShop.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            categoryService = categoriesService;
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var model = categoryService.CategoryDetails(id);

            return View(model);
        }
    }
}
