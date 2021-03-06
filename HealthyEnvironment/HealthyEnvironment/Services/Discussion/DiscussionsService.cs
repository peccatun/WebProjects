﻿using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.Services.Solutions;
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
        private readonly ISolutionsService solutionsService;

        public DiscussionsService(
            ApplicationDbContext dbContext,
            IMediaService mediaService,
            ISolutionsService solutionsService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
            this.solutionsService = solutionsService;
            ;
        }

        public async Task<string> CreateDiscussionAsync(CreateDiscussionViewModel model, string applicationUserId)
        {
            string imageUrl = await this.mediaService.UploadPictureAsync(model.Image);

            var discussion = new Models.Discussion
            {
                About = model.About,
                AdditionalInfo = model.AdditionalInfo,
                ApplicationUserId = applicationUserId,
                CategoryId = model.CategoryId,
                ImageUrl = imageUrl,
                IsApproved = true,
                IsDeleted = false,
                OpenedOn = DateTime.UtcNow,
            };

            await this.dbContext.AddAsync(discussion);
            await this.dbContext.SaveChangesAsync();

            return discussion.Id;
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

        public DiscussionDetailsViewModel GetDiscussionDetails(string discussionId)
        {
            DiscussionDetailsViewModel discussion = this.dbContext
                .Discussions
                .Where(d => d.Id == discussionId)
                .Select(d => new DiscussionDetailsViewModel
                {
                    DiscussionId = d.Id,
                    About = d.About,
                    AdditionalInfo = d.AdditionalInfo,
                    CreatedOn = d.OpenedOn,
                    CreatorName = d.ApplicationUser.UserName,
                    ImageUrl = d.ImageUrl,
                })
                .FirstOrDefault();

            discussion.DiscussionSolutions = this.solutionsService.GetDiscussionSolutons(discussionId);

            return discussion;
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
                    AdditionalInfo = d.AdditionalInfo.Length > 500 ? d.AdditionalInfo.Substring(0,500) + " ..." : d.AdditionalInfo,
                    CategoryName = d.Category.Name,
                    CreatorName = d.ApplicationUser.UserName,
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
