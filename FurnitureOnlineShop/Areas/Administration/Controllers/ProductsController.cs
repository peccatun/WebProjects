using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        public IActionResult CreateProduct()
        {
            return this.View();
        }
    }
}
