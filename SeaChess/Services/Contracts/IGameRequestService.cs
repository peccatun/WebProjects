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
    }
}
