using SeaChess.InputModels.GameSign;
using System.Threading.Tasks;

namespace SeaChess.Services.Contracts
{
    public interface IGameSignService
    {
        Task CreateGameSign(GameSignInputModel inputModel);

        bool HasGameSign(long gameId);

        Task UpdateGameSign(GameSignInputModel inputModel);
    }
}
