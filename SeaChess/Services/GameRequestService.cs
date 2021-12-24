using SeaChess.Services.Contracts;
using SeaChess.Data;
using SeaChess.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using SeaChess.Models;

namespace SeaChess.Services
{


    public class GameRequestService : IGameRequestService
    {
        private readonly ApplicationDbContext dbContext;

        public GameRequestService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddGameRequestAsync(string userId)
        {
            GameRequest gameRequest = new GameRequest
            {
                ApplicationUserId = userId,
                HasPlayed = false,
                IsDeleted = false,
                RequestDate = DateTime.Now,
            };

            await dbContext.GameRequests.AddAsync(gameRequest);
            await dbContext.SaveChangesAsync();
        }

        public Queue<GameRequestDto> GetGameRequests()
        {

            List<GameRequestDto> requests = dbContext
                                        .GameRequests
                                        .Where(gr => !gr.IsDeleted && !gr.HasPlayed)
                                        .Select(gr => new GameRequestDto
                                        {
                                            Id = gr.Id,
                                            ApplicationUserId = gr.ApplicationUserId,
                                            RequestDate = gr.RequestDate,
                                        })
                                        .OrderBy(gr => gr.RequestDate)
                                        .ToList();

            Queue<GameRequestDto> requestQueue = new Queue<GameRequestDto>(requests);

            return requestQueue;
            
        }

        public async Task UpdateUserRequestDateAsync(string userId)
        {
            GameRequest request = dbContext
                        .GameRequests
                        .Where(r => r.ApplicationUserId == userId && !r.IsDeleted && !r.HasPlayed)
                        .FirstOrDefault();

            request.RequestDate = DateTime.Now;
            await dbContext.SaveChangesAsync();
        }
    }
}
