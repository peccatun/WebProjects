using HealthyEnvironment.Models;
using HealthyEnvironment.Data;
using HealthyEnvironment.ViewModels.Informations;
using System.Threading.Tasks;
using System;
using HealthyEnvironment.Services.Media;

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
    }
}
