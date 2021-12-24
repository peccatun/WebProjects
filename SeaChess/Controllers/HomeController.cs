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
        private readonly IHubContext<GameHub> gameHub;
        private readonly Queue<string> playerQueue;


        public HomeController(IHubContext<GameHub> gameHub)
        {
            this.gameHub = gameHub;
            playerQueue = new Queue<string>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StartGame(string userId)
        {
            if (playerQueue.Contains(userId))
            {
                return StatusCode(202);
            }

            playerQueue.Enqueue(userId);

            if (playerQueue.Count >= 2)
            {
                // start Game
            }
            else
            {
                await gameHub.Clients.User(userId).SendAsync("lookingForOponent");
            }


            return Ok();
        }
    }
}
