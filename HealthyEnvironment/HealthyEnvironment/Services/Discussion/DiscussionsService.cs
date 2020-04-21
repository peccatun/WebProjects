using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Discussions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Discussion
{
    public class DiscussionsService : IDiscussionsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public DiscussionsService(ApplicationDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task CreateDiscussionAsync(CreateDiscussionViewModel model, string applicationUserId)
        {
            string imageUrl = await this.mediaService.UploadPictureAsync(model.Image);

            var discussion = new Models.Discussion
            {
                About = model.About,
                AdditionalInfo = model.AdditionalInfo,
                ApplicationUserId = applicationUserId,
                CategoryId = model.CategoryId,
                ImageUrl = imageUrl,
                IsApproved = false,
                IsDeleted = false,
                OpenedOn = DateTime.UtcNow,
            };

            await this.dbContext.AddAsync(discussion);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<DiscussionCategoryDetailsViewModel> GetDiscussionCategories()
        {
            IEnumerable<DiscussionCategoryDetailsViewModel> discussionCategories = this.dbContext
                .Categories
                .Where(c => c.Discussions.Any(d => d.IsApproved && !c.IsDeleted))
                .Select(c => new DiscussionCategoryDetailsViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    ImageUrl = c.ImageUrl,
                    DiscussionsCount = c.Discussions.Count(d => d.CategoryId == c.Id)
                })
                .ToList();

                return discussionCategories;
        }

        public IEnumerable<DiscussionDetailViewModel> GetDiscussionsInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
