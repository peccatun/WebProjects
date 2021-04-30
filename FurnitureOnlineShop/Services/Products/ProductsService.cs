using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureOnlineShop.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AllProductsCollectionViewModel GetAllProductsInCategory(int subCategoryId)
        {
            List<AllProductsViewModel> productsViewModel = dbContext
                .Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .Select(p => new AllProductsViewModel
                {
                    ProductId = p.Id,
                    Description = p.Description,
                    Price = p.Price,
                    ProductName = p.ProductName,
                    Color = p.Color,
                })
                .ToList();

            string subCategoryName = dbContext
                .SubCategories
                .Where(c => c.Id == subCategoryId)
                .Select(c => c.SubCategoryName)
                .FirstOrDefault();

            AllProductsCollectionViewModel model = new AllProductsCollectionViewModel
            {
                AllProductsList = productsViewModel,
                CategoryName = subCategoryName,
            };
            return model;
        }

        //Create the view and get the view data with this service method!!!
    }
}
