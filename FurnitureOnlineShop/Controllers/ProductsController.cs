using FurnitureOnlineShop.Services.Products;
using FurnitureOnlineShop.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FurnitureOnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public IActionResult AllProductsInCategory(int categoryId)
        {
            AllProductsCollectionViewModel productsModel = this.productsService.GetAllProductsInCategory(categoryId);
            return this.View(productsModel);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ProductDetailsViewModel productDetails = productsService.ProductDetails(id);

            return View(productDetails);
        }
    }
}
