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

        public AllProductsCollectionViewModel GetAllProductsInCategory(int categoryId)
        {
            List<AllProductsViewModel> productsViewModel = dbContext
                .Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new AllProductsViewModel
                {
                    ProductId = p.Id,
                    Description = p.Description,
                    Price = p.Price,
                    ProductName = p.ProductName,
                    Color = p.Color,
                })
                .ToList();

            string categoryName = dbContext
                .Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.CategoryName)
                .FirstOrDefault();

            AllProductsCollectionViewModel model = new AllProductsCollectionViewModel
            {
                AllProductsList = productsViewModel,
                CategoryName = categoryName,
            };
            return model;
        }

        //Create the view and get the view data with this service method!!!
    }
}
