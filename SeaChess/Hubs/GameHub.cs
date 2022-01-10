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

        public GameHub(IGameRequestService requestService, IGameService gameService)
        {
            this.requestService = requestService;
            this.gameService = gameService;
            requestQueue = requestService.GetGameRequests();
        }

        public async Task StartGame(string userId)
        {
            if (requestQueue.Any(rq => rq.ApplicationUserId == userId))
            {
                await requestService.UpdateUserRequestDateAsync(userId);
                requestQueue = requestService.GetGameRequests();

                if (requestQueue.Count >= 2)
                {
                    await CallChooseSign();
                    return;
                }

                await Clients.Caller.SendAsync("lookingForOponent");
                return;
            }

            await requestService.AddGameRequestAsync(userId);
            requestQueue = requestService.GetGameRequests();

            if (requestQueue.Count >= 2)
            {
                await CallChooseSign();

            }
            else
            {
                await Clients.Caller.SendAsync("lookingForOponent");
            }
        }

        private async Task CallChooseSign()
        {
            GameRequestDto playerOne = requestQueue.Dequeue();
            GameRequestDto playerTwo = requestQueue.Dequeue();
            await gameService.StartGameAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
            await requestService.SetHasPlayedAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
            await Clients.User(playerOne.ApplicationUserId).SendAsync("chooseSign");
            await Clients.User(playerTwo.ApplicationUserId).SendAsync("chooseSign");
        }
    }
}
