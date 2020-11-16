using FurnitureOnlineShop.Services.Products;
using FurnitureOnlineShop.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        //Create AllProductsInCategory Action;
        [HttpGet]
        public IActionResult AllProductsInCategory(int categoryId)
        {
            AllProductsCollectionViewModel productsModel = this.productsService.GetAllProductsInCategory(categoryId);
            return this.View(productsModel);
        }
    }
}
