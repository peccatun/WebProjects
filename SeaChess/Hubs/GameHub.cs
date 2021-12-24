using Microsoft.AspNetCore.SignalR;
using SeaChess.Dto;
using SeaChess.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SeaChess.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameRequestService requestService;
        private Queue<GameRequestDto> requestQueue;

        public GameHub(IGameRequestService gameRequestService)
        {
            this.requestService = gameRequestService;
            requestQueue = gameRequestService.GetGameRequests();
        }

        public async Task StartGame(string userId)
        {
            if (requestQueue.Any(rq => rq.ApplicationUserId == userId))
            {
                await requestService.UpdateUserRequestDateAsync(userId);
                await Clients.Caller.SendAsync("lookingForOponent");
                return;
            }

            await requestService.AddGameRequestAsync(userId);
            requestQueue = requestService.GetGameRequests();

            if (requestQueue.Count >= 2)
            {
                //start game
            }
            else
            {
                await Clients.Caller.SendAsync("lookingForOponent");
            }
        }
    }
}
