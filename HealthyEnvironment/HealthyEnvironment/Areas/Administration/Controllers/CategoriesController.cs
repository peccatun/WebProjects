using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles ="Admin")]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
