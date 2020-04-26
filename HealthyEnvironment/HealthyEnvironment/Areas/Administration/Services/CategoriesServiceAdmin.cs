using HealthyEnvironment.Areas.Administration.ViewModels.Categories;
using HealthyEnvironment.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public class CategoriesServiceAdmin : ICategoriesServiceAdmin
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesServiceAdmin(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = dbContext
                .Categories
                .OrderBy(c => c.CreateOn)
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .ToList();

            return categories;
        }

        public CategoryDetailsViewModel GetCategoryDetails(string categoryId)
        {
            CategoryDetailsViewModel category = dbContext.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryDetailsViewModel
                {
                    CategoryId = c.Id,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    IsApproved = c.IsApproved,
                    IsDeleted = c.IsDeleted,
                })
                .FirstOrDefault();

            return category;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryViewModel model)
        {
            var category = this.dbContext
                .Categories
                .FirstOrDefault(c => c.Id == model.CategoryId);

            category.IsApproved = model.IsApproved;
            category.IsDeleted = model.IsDeleted;

            await dbContext.SaveChangesAsync();
        }
    }
}
