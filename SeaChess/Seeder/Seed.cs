using SeaChess.Data;
using System.Linq;
using System.Reflection;
using SeaChess.GlobalConstants;
using SeaChess.Models;

namespace SeaChess.Seeder
{
    public class Seed
    {
        private readonly ApplicationDbContext dbContext;

        public Seed(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SeedData() 
        {
            if (HasGameStateData())
            {
                return;
            }

            FieldInfo[] states = typeof(Globals.GameState).GetFields();

            for (int i = 0; i < states.Length; i++)
            {
                string currentState = states[i].GetValue(states[i].Name).ToString();
                GameState gameState = new GameState
                {
                    IsDel = false,
                    State = currentState,
                };

                dbContext.GameStates.Add(gameState);
            }

            dbContext.SaveChanges();
        }

        private bool HasGameStateData() 
        {
            return dbContext.GameStates.Any(gs => !gs.IsDel);
        }
    }
}
