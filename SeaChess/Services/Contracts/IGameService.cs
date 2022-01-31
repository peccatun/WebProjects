using SeaChess.Dto.Game;
using System.Threading.Tasks;

namespace SeaChess.Services.Contracts
{
    public interface IGameService
    {
        Task<long> StartGameAsync(string playerOneId, string playerTwoId);

        /// <summary>
        /// Return an object with the ids of the players.
        /// </summary>
        /// <param name="gameId">gameId</param>
        /// <returns></returns>
        GamePlayersInfoDto GetPlayerIds(long gameId);
    }
}
