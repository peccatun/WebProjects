using HealthyEnvironment.Data;
using HealthyEnvironment.Models;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public CategoriesService(ApplicationDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public IEnumerable<CategoryDropDownViewModel> GetCategoryNameAndId()
        {
            var categories = dbContext
                .Categories
                .Where(c => c.IsApproved && !c.IsDeleted)
                .Select(c => new CategoryDropDownViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                })
                .ToList();

            return categories;
        }

        public async Task CreateCategoryAsync(CreateCategoryViewModel model)
        {
            string path = await this.mediaService.UploadPictureAsync(model.Image);

            if (path == null)
            {
                return;
            }

            Category category = new Category
            {
                Name = model.Name,
                ImageUrl = path,
                IsApproved = false,
                IsDeleted = false,
                CreateOn = DateTime.UtcNow,
            };

            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = dbContext
                .Categories
                .Where(c => c.IsApproved && !c.IsDeleted)
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .ToList();

            return categories;
        }

        public string GetCategoryName(string categoryId)
        {
            string categoryName = this.dbContext
                .Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.Name)
                .FirstOrDefault();

            return categoryName;
        }
    }
}
