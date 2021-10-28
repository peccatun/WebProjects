using FurnitureOnlineShop.Areas.Administration.InputModels.Products;
using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using FurnitureOnlineShop.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using FurnitureOnlineShop.Services.Images;

namespace FurnitureOnlineShop.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageService imageService;

        public ProductsService(ApplicationDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
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
                    Color = p.Color.ColorName,
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

        public async Task InsertProduct(CreateProductInputModel inputModel)
        {
            int imageId = await imageService.SaveImageToDbAsync(inputModel.ProductImagePath);
            //TODO :Alter database. Product must have image id and category must have image id.
            Product product = new Product
            {
                ColorId = inputModel.ColorId,
                CreatedOn = DateTime.Now,
                Description = inputModel.Description,
                IsDeleted = false,
                Price = inputModel.Price,
                Quantity = inputModel.Quantity,
                SubCategoryId = inputModel.SubCategoryId,
                ProductName = inputModel.ProductName,
                ImageId = imageId,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public ProductDetailsViewModel ProductDetails(int id)
        {
            ProductDetailsViewModel model = dbContext
                .Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new ProductDetailsViewModel
                {
                    ImagePath = imageService.GetImagePathByImageId(p.ImageId),
                    Color = p.Color.ColorName,
                    Price = p.Price,
                    ProductDescription = p.Description,
                    ProductId = p.Id,
                    ProductName = p.ProductName,
                })
                .FirstOrDefault();

            return model;
        }
    }
}
