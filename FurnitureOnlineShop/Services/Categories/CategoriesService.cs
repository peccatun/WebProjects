using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using FurnitureOnlineShop.ViewModels.Categories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateCategoryAsync(CreateCategoryInputModel input)
        {
            Category category = new Category
            {
                CategoryName = input.CategoryName,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
            };

            await dbContext.Categories.AddAsync(category);

            await dbContext.SaveChangesAsync();
        }

        public AllCategoriesViewModel GetAllCategories()
        {
            IEnumerable<CategoryDetailsViewModel> model = dbContext.Categories
                .Select(c => new CategoryDetailsViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                })
                .ToList();

            AllCategoriesViewModel AllCategories = new AllCategoriesViewModel
            {
                AllCategories = model,
            };

            return AllCategories;
        }
    }
}
