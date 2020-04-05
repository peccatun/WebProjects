using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class InformationController : Controller
    {
        [HttpGet("/Information")]
        public IActionResult InformationHome()
        {
            return this.View();
        }
    }
}
