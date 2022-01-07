using SeaChess.Data;
using SeaChess.Services.Contracts;
using System.Linq;

namespace SeaChess.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly ApplicationDbContext dbContext;

        public GameStateService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetIdByName(string name)
        {
            int stateId = dbContext
                            .GameStates
                            .Where(gs => !gs.IsDel && gs.State == name)
                            .Select(gs => gs.Id)
                            .FirstOrDefault();

            return stateId;
        }
    }
}
