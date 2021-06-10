using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.InputModels.Colors;
using FurnitureOnlineShop.Areas.Administration.InputModels.Products;
using FurnitureOnlineShop.Areas.Administration.ViewModels;
using FurnitureOnlineShop.Services.Categories;
using FurnitureOnlineShop.Services.Colors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IColorService colorService;

        public ProductsController(ICategoriesService categoriesService, IColorService colorService)
        {
            this.categoriesService = categoriesService;
            this.colorService = colorService;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductInputModel model = new CreateProductInputModel
            {
                Categories = categoriesService.GetCategoryDropDownItems(),
                Colors = colorService.GetColors(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel model)
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ProductsMenu()
        {
            return View();
        }

        [HttpGet]
        public List<SubCategoryDropDownMenuViewModel> GetSubCategories(int categoryId)
        {
            List<SubCategoryDropDownMenuViewModel> subCategories = categoriesService.GetSubCategoryDropDownItems(categoryId);

            return subCategories;
        }

        [HttpGet]
        public List<ColorViewModel> AddColor(string color)
        {
            ColorInputModel model = new ColorInputModel
            {
                ColorName = color,
                IsDeleted = false,
            };

            colorService.AddColor(model);

            List<ColorViewModel> colors = colorService.GetColors();

            return colors;
        }
    }
}
