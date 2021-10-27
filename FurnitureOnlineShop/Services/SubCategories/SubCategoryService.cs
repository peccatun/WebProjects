using System;
using System.Linq;
using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Services.Images;
using FurnitureOnlineShop.ViewModels.Products;
using FurnitureOnlineShop.ViewModels.SubCategories;

namespace FurnitureOnlineShop.Services.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageService imageService;

        public SubCategoryService(ApplicationDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public SubCategoryItemsViewModel GetSubCategoryItems(long subCategoryId)
        {
            SubCategoryItemsViewModel model = new SubCategoryItemsViewModel
            {
                SubCategoryName = dbContext
                                .SubCategories
                                .Where(sb => sb.Id == subCategoryId)
                                .Select(sb => sb.SubCategoryName).FirstOrDefault(),
                Products = dbContext
                                .Products
                                .Where(p => p.SubCategoryId == subCategoryId)
                                .Select(p => new ProductsViewModel
                                {
                                    ProductId = p.Id,
                                    Price = p.Price,
                                    ImagePath = imageService.GetImagePathByImageId(p.ImageId),
                                    ProductName = p.ProductName,
                                    Color = p.Color.ColorName,
                                    Description = p.Description,
                                    
                                }).ToList()
            };

            return model;
        }
    }
}
