using HealthyEnvironment.Data;
using HealthyEnvironment.Models;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Categories;
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

        public async Task CreateCategoryAsync(CreateCategoryViewModel model)
        {
            string path = await this.mediaService.UploadPictureAsync(model.Image);

            Category category = new Category
            {
                Name = model.Name,
                ImageUrl = path,
                IsApproved = false,
            };

            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = dbContext
                .Categories
                .Where(c => c.IsApproved)
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .ToList();

            return categories;
        }
    }
}
