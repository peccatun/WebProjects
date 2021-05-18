using FurnitureOnlineShop.Areas.Administration.InputModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductInputModel model = new CreateProductInputModel();

            return this.View(model);
        }

        public IActionResult ProductsMenu()
        {
            return View();
        }


    }
}
