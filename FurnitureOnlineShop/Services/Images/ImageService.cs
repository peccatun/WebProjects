using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteImageByIdAsync(int imageId)
        {
            Image imageToDelete = dbContext.Images.FirstOrDefault(c => c.Id == imageId);

            if (imageToDelete != null)
            {
                dbContext.Images.Remove(imageToDelete);
                await dbContext.SaveChangesAsync();
            }
        }

        public string GetImagePathByImageId(int categoryImageId)
        {
            byte[] imageBytes = dbContext
                .Images
                .Where(c => c.Id == categoryImageId)
                .Select(c => c.ImageBytes)
                .FirstOrDefault();

            string imageBase64 = Convert.ToBase64String(imageBytes);

            string imagePath = string.Format("data:image/png;base64,{0}", imageBase64);

            return imagePath;
        }

        public async Task<int> SaveImageToDbAsync(IFormFile file)
        {
            byte[] imageBytes;

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            Image categoryImage = new Image
            {
                CreatedOn = DateTime.UtcNow,
                ImageName = file.FileName,
                ImageBytes = imageBytes,
            };

            await dbContext.Images.AddAsync(categoryImage);
            await dbContext.SaveChangesAsync();

            return categoryImage.Id;
        }
    }
}
