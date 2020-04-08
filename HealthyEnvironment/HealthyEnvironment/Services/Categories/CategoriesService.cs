using HealthyEnvironment.Data;
using HealthyEnvironment.ViewModels.Categories;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEnvironment.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = dbContext
                .Categories
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
