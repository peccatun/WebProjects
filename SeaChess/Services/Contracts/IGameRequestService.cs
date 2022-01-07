using System.Collections.Generic;
using System.Threading.Tasks;
using SeaChess.Dto;

namespace SeaChess.Services.Contracts
{
    public interface IGameRequestService
    {
        Queue<GameRequestDto> GetGameRequests();

        Task UpdateUserRequestDateAsync(string userId);

        Task AddGameRequestAsync(string userId);

        /// <summary>
        /// Update Has Played column for two players when they start a game
        /// </summary>
        /// <param name="playerOneId">player one id</param>
        /// <param name="playerTwoId">player two id</param>
        /// <returns></returns>
        Task SetHasPlayedAsync(string playerOneId, string playerTwoId);
    }
}
