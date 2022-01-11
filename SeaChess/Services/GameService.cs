using SeaChess.Data;
using SeaChess.GlobalConstants;
using SeaChess.Models;
using SeaChess.Services.Contracts;
using System.Threading.Tasks;

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
