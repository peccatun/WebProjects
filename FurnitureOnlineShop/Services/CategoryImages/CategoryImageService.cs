using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.CategoryImages
{
    public class CategoryImageService : ICategoryImageService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryImageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteCategoryImageByIdAsync(int categoryImageId)
        {
            CategoryImage categoryImageToDelete = dbContext.CategoryImages.FirstOrDefault(c => c.Id == categoryImageId);

            if (categoryImageToDelete != null)
            {
                dbContext.CategoryImages.Remove(categoryImageToDelete);
                await dbContext.SaveChangesAsync();
            }
        }

        public string GetImagePathByImageId(int categoryImageId)
        {
            byte[] imageBytes = dbContext
                .CategoryImages
                .Where(c => c.Id == categoryImageId)
                .Select(c => c.ImageBytes)
                .FirstOrDefault();

            string imageBase64 = Convert.ToBase64String(imageBytes);

            string imagePath = string.Format("data:image/png;base64,{0}", imageBase64);

            return imagePath;
        }

        public async Task<int> SaveCategoryImageToDb(IFormFile file)
        {
            byte[] imageBytes;

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            CategoryImage categoryImage = new CategoryImage
            {
                CreatedOn = DateTime.UtcNow,
                ImageName = file.FileName,
                ImageBytes = imageBytes,
            };

            await dbContext.CategoryImages.AddAsync(categoryImage);
            await dbContext.SaveChangesAsync();

            return categoryImage.Id;
        }
    }
}
