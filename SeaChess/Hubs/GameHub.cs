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
        private readonly IGameService gameService;
        private Queue<GameRequestDto> requestQueue;

        public GameHub(IGameRequestService gameRequestService, IGameService gameService)
        {
            this.requestService = gameRequestService;
            this.gameService = gameService;
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
                GameRequestDto playerOne = requestQueue.Dequeue();
                GameRequestDto playerTwo = requestQueue.Dequeue();
                await gameService.StartGameAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
                await requestService.SetHasPlayedAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
                //Call choose sign method in the view!!!
            }
            else
            {
                await Clients.Caller.SendAsync("lookingForOponent");
            }
        }
    }
}
