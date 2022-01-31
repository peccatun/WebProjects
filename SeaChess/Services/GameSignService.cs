using SeaChess.Data;
using SeaChess.InputModels.GameSign;
using SeaChess.Models;
using SeaChess.Services.Contracts;
using System.Threading.Tasks;
using System.Linq;

namespace SeaChess.Services
{
    public class GameSignService : IGameSignService
    {
        private readonly ApplicationDbContext dbContext;

        public GameSignService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateGameSign(GameSignInputModel inputModel)
        {
            GameSign gameSign = new GameSign
            {
                IsDel = false,
                GameId = inputModel.GameId,
                PlayerOneId = inputModel.PlayerOneId,
                PlayerOneSign = inputModel.PlayerOneSign,
                PlayerTwoId = inputModel.PlayerTwoId,
                PlayerTwoSign = inputModel.PlayerTwoSign,
            };

            await dbContext.GameSigns.AddAsync(gameSign);
            await dbContext.SaveChangesAsync();
        }

        public bool HasGameSign(long gameId)
        {
            return dbContext.GameSigns.Any(gs => gs.GameId == gameId && !gs.IsDel);
        }

        public async Task UpdateGameSign(GameSignInputModel inputModel)
        {
            long gameId = inputModel.GameId;

            GameSign gameSign = dbContext
                .GameSigns
                .Where(gs => gs.GameId == gameId && !gs.IsDel)
                .FirstOrDefault();

            gameSign.PlayerTwoId = inputModel.PlayerTwoId;
            gameSign.PlayerTwoSign = inputModel.PlayerTwoSign;

            await dbContext.SaveChangesAsync();
        }
    }
}
