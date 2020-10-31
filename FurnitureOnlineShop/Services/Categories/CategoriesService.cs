using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.ViewModels.Categories;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureOnlineShop.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
