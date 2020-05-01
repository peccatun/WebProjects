using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Categories;
using HealthyEnvironment.ViewModels.Products;
using Newtonsoft.Json;
using System.Linq;

namespace HealthyEnvironment.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMediaService mediaService;

        public ProductsService(
            ApplicationDbContext dbContext,
            IMediaService mediaService
            )
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public ProductCategoryListViewModel GetProductCategories()
        {
            var productCategories = this.dbContext
                .Categories
                .Where(c => c.Products.Any(p => p.Count > 0))
                .Select(c => new ProductCategoryListItemViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    ImageUrl = c.ImageUrl,
                    ProductsCount = c.Products.Count(p => p.Count > 0),
                })
                .ToList();


            ProductCategoryListViewModel productCategoriesModel = new ProductCategoryListViewModel
            {
                ProductsCategoryList = productCategories,
            };

            return productCategoriesModel;
        }

        public ProductDetailsViewModel GetProductDetails(string productId)
        {
            string json = this.dbContext
                .Products
                .Where(d => d.Id == productId)
                .Select(d => d.AdditionalImageUrlsJson)
                .FirstOrDefault();

            string[] additionalImageUrls = this.mediaService.ConvertJsonToStringArray(json);

            ProductDetailsViewModel product = this.dbContext
                .Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDetailsViewModel
                {
                    ProductName = p.Name,
                    ProductId = p.Id,
                    HeadImage = p.ImageUrl,
                    Count = p.Count,
                    Price = p.Price,
                    ProductDescription = p.Discription,
                    AdditionalImageUrls = additionalImageUrls,
                })
                .FirstOrDefault();

            return product;
        }

        public ProductListViewModel GetProductsList(string categoryId)
        {
            var products = this.dbContext
                .Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductListItemViewModel
                {
                    ProductId    = p.Id,
                    ProductName = p.Name,
                    Discription = p.Discription,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                })
                .ToList();

            ProductListViewModel productsModel = new ProductListViewModel
            {
                Products = products,
            };

            return productsModel;
        }
    }
}
