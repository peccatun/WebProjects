using HealthyEnvironment.Data;
using HealthyEnvironment.Models;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Solutions
{
    public class SolutionsService : ISolutionsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public SolutionsService(ApplicationDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task CreateSolutionAsync(CreateSolutionViewModel model)
        {
            string imageUrl = await this.mediaService.UploadPictureAsync(model.Image);

            Solution solution = new Solution
            {
                Content = model.Content,
                ImageUrl = imageUrl,
                PostedOn = DateTime.UtcNow,
                ApplicationUserId = model.ApplicationUserId,
                DiscussionId = model.DiscussionId,
                IsDeleted = false,
            };

            await dbContext.AddAsync(solution);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<SolutionDetailsViewModel> GetDiscussionSolutons(string discussionId)
        {
            IEnumerable<SolutionDetailsViewModel> solutions = this.dbContext
                .Solutions
                .Where(s => s.DiscussionId == discussionId)
                .OrderBy(s => s.PostedOn)
                .Select(s => new SolutionDetailsViewModel
                {
                    Content = s.Content,
                    ImageUrl = s.ImageUrl,
                    CreatedOn = s.PostedOn,
                    CreatorUserName = s.ApplicationUser.UserName,
                })
                .ToList();

            return solutions;
        }
    }
}
