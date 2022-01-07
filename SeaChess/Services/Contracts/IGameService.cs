using System.Threading.Tasks;

namespace SeaChess.Services.Contracts
{
    public interface IGameService
    {
        Task StartGameAsync(string playerOneId, string playerTwoId);
    }
}
