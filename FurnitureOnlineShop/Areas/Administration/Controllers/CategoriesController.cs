using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.ViewModels.Categories;
using FurnitureOnlineShop.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult CategoriesMenu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoriesService.CreateCategoryAsync(model);

            return RedirectToAction("Index","Home",new { area =""});
        }

        [HttpGet]
        public IActionResult CreateSubCategory()
        {
            CreateSubCategoryInputModel model = new CreateSubCategoryInputModel();

            model.CategoryDropDownMenu = categoriesService.GetCategoryDropDownItems();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoriesService.CreateSubCategory(model);

            return RedirectToAction("Index","Home", new { area=""});
        }

        [HttpGet]
        public IActionResult AllCategories()
        {
            AllCategoryCollectionViewModel model = categoriesService.GetAllCategoriesForAdmin();

            return View(model);
        }

        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {
            EditCategoryViewModel model = categoriesService.GetEditCategoryInfo(categoryId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await categoriesService.DeleteCategoryByIdAsync(categoryId);

            var redirectUrl = "AllCategories";

            return Json(new { Url = redirectUrl });
        }
    }
}
