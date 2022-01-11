using System.Threading.Tasks;

namespace SeaChess.Services.Contracts
{
    public interface IGameService
    {
        Task<long> StartGameAsync(string playerOneId, string playerTwoId);
    }
}
