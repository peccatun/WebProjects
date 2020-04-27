using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Products;
using HealthyEnvironment.ViewModels.Categories;
using HealthyEnvironment.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService cagoriesService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService cagoriesService
            )
        {
            this.productsService = productsService;
            this.cagoriesService = cagoriesService;
        }

        public IActionResult ProductDetails(string productId)
        {
            ProductDetailsViewModel model = this.productsService.GetProductDetails(productId);
            return this.View(model);
        }

        [HttpGet("/Products")]
        public IActionResult ProductCategories()
        {
            ProductCategoryListViewModel model = productsService.GetProductCategories();
            return this.View(model);
        }

        public IActionResult ProductsInCategory(string categoryId)
        {
            ProductListViewModel model = productsService.GetProductsList(categoryId);
            return this.View(model);
        }
    }
}
