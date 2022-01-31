using SeaChess.Data;
using SeaChess.Dto.Game;
using SeaChess.GlobalConstants;
using SeaChess.Models;
using SeaChess.Services.Contracts;
using System.Threading.Tasks;
using System.Linq;

namespace SeaChess.Services
{
    public class GameService : IGameService
    {
        private readonly IGameStateService gameStateService;
        private readonly ApplicationDbContext dbContext;

        public GameService(ApplicationDbContext dbContext, IGameStateService gameStateService)
        {
            this.gameStateService = gameStateService;
            this.dbContext = dbContext;
        }

        public GamePlayersInfoDto GetPlayerIds(long gameId)
        {
            GamePlayersInfoDto dto = dbContext
                .Game
                .Where(g => !g.IsDel && g.Id == gameId)
                .Select(g => new GamePlayersInfoDto
                {
                    PlayerOneId = g.PlayerOneId,
                    PlayerTwoId = g.PlayerTwoId,
                })
                .FirstOrDefault();

            return dto;
        }

        public async Task<long> StartGameAsync(string playerOneId, string playerTwoId)
        {
            int gameStateId = gameStateService.GetIdByName(Globals.GameState.CHOOSE_SIGN);

            Game game = new Game
            {
                IsDel = false,
                PlayerOneId = playerOneId,
                PlayerTwoId = playerTwoId,
                GameStateId = gameStateId,
            };

            await dbContext.Game.AddAsync(game);
            await dbContext.SaveChangesAsync();
            return game.Id;
        }
    }
}
