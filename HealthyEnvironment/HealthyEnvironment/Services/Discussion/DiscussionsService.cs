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
                    DiscussionsCount = c.Discussions.Count(d => d.CategoryId == c.Id && d.IsApproved)
                })
                .ToList();

                return discussionCategories;
        }

        public IEnumerable<DiscussionsInCategoryDetailViewModel> GetDiscussionsInCategory(string categoryId)
        {
            IEnumerable<DiscussionsInCategoryDetailViewModel> discussionsInCategory = this.dbContext
                .Discussions
                .Where(d => d.CategoryId == categoryId)
                .Where(d => d.IsApproved && !d.IsDeleted)
                .OrderByDescending(d => d.OpenedOn)
                .Select(d => new DiscussionsInCategoryDetailViewModel
                {
                    About = d.About,
                    AdditionalInfo = d.AdditionalInfo.Length > 50 ? d.AdditionalInfo.Substring(0,50) + "..." : d.AdditionalInfo,
                    CategoryName = d.Category.Name,
                    CreatedOn = d.OpenedOn,
                    DiscussionId = d.Id,
                    ImageUrl = d.ImageUrl,
                    SolutionsCount = d.Solutions.Count(s => s.DiscussionId == d.Id)
                })
                .ToList();

            return discussionsInCategory;
        }
    }
}
