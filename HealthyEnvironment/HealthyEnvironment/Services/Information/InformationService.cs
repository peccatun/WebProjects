using HealthyEnvironment.Models;
using HealthyEnvironment.Data;
using HealthyEnvironment.ViewModels.Informations;
using System.Threading.Tasks;
using System;
using HealthyEnvironment.Services.Media;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEnvironment.Services.Information
{
    public class InformationService : IInformationService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public InformationService(
            ApplicationDbContext dbContext,
            IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task Create(CreateInfomationViewModel model, string applicationUserId)
        {
            string imgPath = await this.mediaService.UploadPictureAsync(model.Image);

            Models.Information information = new Models.Information
            {
                About = model.About,
                Content = model.Content,
                ImageUrl = imgPath,
                CategoryId = model.CategoryId,
                ApplicationUserId = applicationUserId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                IsApproved = false,
            };

            await dbContext.AddAsync(information);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<InformationCategoryDetailsViewModel> GetInformationCategories()
        {
            IEnumerable<InformationCategoryDetailsViewModel> informationCategories = dbContext
                .Categories
                .Where(c => c.Information.Any(i => i.IsApproved && !i.IsDeleted))
                .Select(c => new InformationCategoryDetailsViewModel
                {
                    CategoryName = c.Name,
                    ImageUrl = c.ImageUrl,
                    InformationCount = c.Information.Count(i => i.IsApproved && !i.IsDeleted)
                })
                .ToList();

            return informationCategories;
        }
    }
}
