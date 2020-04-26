using HealthyEnvironment.Areas.Administration.ViewModels.Products;
using HealthyEnvironment.Data;
using HealthyEnvironment.Models;
using HealthyEnvironment.Services.Media;
using System;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public class ProductsServiceAdmin : IProductsServiceAdmin
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public ProductsServiceAdmin(
            ApplicationDbContext dbContext,
            IMediaService mediaService
            )
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task CreateProductAsync(CreateProductViewModel model)
        {
            string imageUrl = await this.mediaService.UploadPictureAsync(model.Image);

            string additionalImageUrls = await this.mediaService.UploadMultiplePicturesAsync(model.AdditionalImages);

            Product product = new Product
            {
                Name = model.Name,
                Discription = model.Discription,
                Price = model.Price,
                IsDeleted = false,
                CategoryId = model.CategoryId,
                Count = model.Count,
                CreatedOn = DateTime.UtcNow,
                ImageUrl = imageUrl,
                AdditionalImageUrlsJson = additionalImageUrls,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
