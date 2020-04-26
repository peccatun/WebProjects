using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult ProductDetails()
        {
            return this.View();
        }

        [HttpGet("/Products")]
        public IActionResult ProductsHome()
        {
            return this.View();
        }
    }
}
