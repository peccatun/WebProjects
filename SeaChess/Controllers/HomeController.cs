using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SeaChess.Hubs;
using SeaChess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SeaChess.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController(IHubContext<GameHub> gameHub)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
