using HealthyEnvironment.Models;
using HealthyEnvironment.Data;
using HealthyEnvironment.ViewModels.Informations;
using System.Threading.Tasks;
using System;
using HealthyEnvironment.Services.Media;
using System.Collections.Generic;
using System.Linq;
using HealthyEnvironment.Services.Comments;

namespace HealthyEnvironment.Services.Information
{
    public class InformationService : IInformationService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;
        private readonly ICommentsService commentsService;

        public InformationService(
            ApplicationDbContext dbContext,
            IMediaService mediaService,
            ICommentsService commentsService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
            this.commentsService = commentsService;
        }

        public async Task Create(CreateInfomationViewModel model, string applicationUserId)
        {
            string imgPath = await this.mediaService.UploadPictureAsync(model.Image);
            string additionalImageJson = await this.mediaService.UploadMultiplePicturesAsync(model.AdditionalImages);

            Models.Information information = new Models.Information
            {
                About = model.About,
                Content = model.Content,
                ImageUrl = imgPath,
                CategoryId = model.CategoryId,
                ApplicationUserId = applicationUserId,
                CreatedOn = DateTime.UtcNow,
                AdditionalImageUrlsJson = additionalImageJson,
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
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    ImageUrl = c.ImageUrl,
                    InformationCount = c.Information.Count(i => i.IsApproved && !i.IsDeleted)
                })
                .ToList();

            return informationCategories;
        }

        public InformationDetailsViewModel GetInformationDetails(string informationId)
        {
            string imageUrlsJson = this.dbContext
                .Information
                .Where(i => i.Id == informationId)
                .Select(i => i.AdditionalImageUrlsJson)
                .FirstOrDefault();

            string[] additionalImgUrls = this.mediaService.ConvertJsonToStringArray(imageUrlsJson);

            InformationDetailsViewModel information = dbContext
                .Information
                .Where(i => i.Id == informationId)
                .Select(i => new InformationDetailsViewModel
                {
                    InformationId = i.Id,
                    About = i.About,
                    Content = i.Content,
                    CreatedOn = i.CreatedOn,
                    CreatorId = i.ApplicationUserId,
                    CreatorUserName = i.ApplicationUser.UserName,
                    AdditionalImgUrls = additionalImgUrls,
                    ImageUrl = i.ImageUrl,
                })
                .FirstOrDefault();

            information.Comments = this.commentsService.GetCommentDetails(informationId);

            if (information.ImageUrl == null)
            {
                information.ImageUrl = this.SetDefouldImage();
            }

            return information;
        }

        public IEnumerable<InformationInCategoryResumeViewModel> GetInformationInCategory(string categoryId)
        {
            IEnumerable<InformationInCategoryResumeViewModel> informationInCategory = this.dbContext
                .Information
                .Where(i => i.CategoryId == categoryId)
                .Where(i => i.IsApproved && !i.IsDeleted)
                .OrderByDescending(i => i.CreatedOn)
                .Select(i => new InformationInCategoryResumeViewModel
                {
                    InformationId = i.Id,
                    ImageUrl = i.ImageUrl == null ? this.SetDefouldImage() : i.ImageUrl,
                    About = i.About,
                    CreatedOn = i.CreatedOn,
                    CreatorUserName = i.ApplicationUser.UserName,
                    ContentResume = i.Content.Length > 50 ? i.Content.Substring(0,50) + "..." : i.Content,
                })
                
                .ToList();

            return informationInCategory;
        }

        public bool IsValidInformationId(string informationId)
        {
            return this.dbContext.Information.Any(i => i.Id == informationId);
        }

        private string SetDefouldImage()
        {
            return "https://us.123rf.com/450wm/pavelstasevich/pavelstasevich1811/pavelstasevich181101065/112815953-stock-vector-no-image-available-icon-flat-vector.jpg?ver=6";
        }
    }
}
