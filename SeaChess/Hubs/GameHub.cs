using Microsoft.AspNetCore.SignalR;
using SeaChess.Dto;
using SeaChess.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SeaChess.InputModels.SaveSign;
using System;
using SeaChess.InputModels.GameSign;
using SeaChess.Dto.Game;

namespace SeaChess.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameRequestService requestService;
        private readonly IGameSignService gameSignService;
        private readonly IGameService gameService;
        private Queue<GameRequestDto> requestQueue;

        public GameHub(IGameRequestService requestService, IGameSignService gameSignService, IGameService gameService)
        {
            this.gameSignService = gameSignService;
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

        public async Task SavePlayerSign(SignInfo sign) 
        {
            long gameId = sign.GameId;
            GameSignInputModel inputModel = new GameSignInputModel
            {
                GameId = gameId,
            };

            GamePlayersInfoDto playerIds = gameService.GetPlayerIds(gameId);
            string currentUserId = sign.UserId;
            bool isFirstPlayer = playerIds.PlayerOneId == currentUserId;

            //if has game sign returns false,
            //we insert new game sign entity and call 
            //waiting for player two method
            if (!gameSignService.HasGameSign(gameId))
            {
                inputModel.PlayerOneId = sign.UserId;
                inputModel.PlayerOneSign = sign.Sign;
                await gameSignService.CreateGameSign(inputModel);

                if (isFirstPlayer)
                {
                    await Clients.User(currentUserId).SendAsync("waitingForSecondPlayer");
                    await Clients.User(playerIds.PlayerOneId).SendAsync("waitingForYou");
                }
                else
                {
                    await Clients.User(playerIds.PlayerTwoId).SendAsync("waitingForSecondPlayer");
                    await Clients.User(playerIds.PlayerOneId).SendAsync("waitingForYou");
                }

                return;
            }

            inputModel.PlayerTwoId = currentUserId;
            inputModel.PlayerTwoSign = sign.Sign;

            await gameSignService.UpdateGameSign(inputModel);
            await Clients.User(playerIds.PlayerOneId).SendAsync("StartGame");
            await Clients.User(playerIds.PlayerTwoId).SendAsync("StartGame");

            //TODO: Update game state!!!!!
        }

        private async Task CallChooseSign()
        {
            GameRequestDto playerOne = requestQueue.Dequeue();
            GameRequestDto playerTwo = requestQueue.Dequeue();
            long gameId = await gameService
                .StartGameAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
            await requestService.SetHasPlayedAsync(playerOne.ApplicationUserId, playerTwo.ApplicationUserId);
            GameInfoDto gameInfo = new GameInfoDto { GameId = gameId };
            await Clients.User(playerOne.ApplicationUserId).SendAsync("chooseSign", gameInfo);
            await Clients.User(playerTwo.ApplicationUserId).SendAsync("chooseSign", gameInfo);
        }
    }
}
