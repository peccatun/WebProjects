using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class DiscussionsController : Controller
    {
        [HttpGet("/Discussions")]
        public IActionResult DiscussionsHome()
        {
            return this.View();
        }
    }
}
