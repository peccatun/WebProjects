using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.InputModels.Products;
using FurnitureOnlineShop.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FurnitureOnlineShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public ProductsController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductInputModel model = new CreateProductInputModel
            {
                Categories = categoriesService.GetCategoryDropDownItems(),
            };

            return this.View(model);
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


    }
}
