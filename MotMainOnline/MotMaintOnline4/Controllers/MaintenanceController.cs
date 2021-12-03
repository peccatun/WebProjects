using Microsoft.AspNetCore.Mvc;

namespace MotMaintOnline4.Controllers
{
    public class MaintenanceController : Controller
    { 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
