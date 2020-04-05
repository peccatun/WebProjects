using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet("/Categories")]
        public IActionResult CategoriesHome()
        {
            return this.View();
        }
    }
}
