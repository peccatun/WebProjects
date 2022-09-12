using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.ViewModels.Categories;
using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using FurnitureOnlineShop.Services.Images;
using FurnitureOnlineShop.ViewModels.Categories;
using FurnitureOnlineShop.ViewModels.Products;
using FurnitureOnlineShop.ViewModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageService imageService;

        public CategoriesService(ApplicationDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public async Task CreateCategoryAsync(CreateCategoryInputModel input)
        {
            int imageId = await imageService.SaveImageToDbAsync(input.Image);

            Category category = new Category
            {
                CategoryName = input.CategoryName,
                Description = input.Description,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                ImageId = imageId,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateSubCategory(CreateSubCategoryInputModel model)
        {
            SubCategory subCategory = new SubCategory
            {
                CreateOn = DateTime.Now,
                IsDel = false,
                SubCategoryName = model.SubCategoryName,
                CategoryId = model.CategoryId
            };

            await dbContext.SubCategories.AddAsync(subCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryByIdAsync(int categoryId)
        {
            Category categoryToDelete = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (categoryToDelete != null)
            {
                int imageId = categoryToDelete.ImageId;
                await imageService.DeleteImageByIdAsync(imageId);

                dbContext.Categories.Remove(categoryToDelete);
                await dbContext.SaveChangesAsync();
            }

        }

        public AllCategoriesViewModel GetAllCategories()
        {
            IEnumerable<CategoryDetailsViewModel> model = dbContext.Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new CategoryDetailsViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImagePath = imageService.GetImagePathByImageId(c.ImageId),
                    SubCategories = c.SubCategories.Where(sc => sc.CategoryId == c.Id && !c.IsDeleted).Select(sc => new SubCategoryMenuItemViewModel
                    {
                        SubCategoryId = sc.Id,
                        SubCategoryName = sc.SubCategoryName
                    })
                    .ToList()
                })
                .ToList();

            IEnumerable<CategoryMenuItemViewModel> categoryMenuItems = dbContext
                .Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new CategoryMenuItemViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    SubCategories = c.SubCategories.Where(sc => sc.CategoryId == c.Id && !sc.IsDel).Select(sc => new SubCategoryMenuItemViewModel
                    {
                        SubCategoryId = sc.Id,
                        SubCategoryName = sc.SubCategoryName
                    })
                    .ToList()
                })
                .ToList();

            CategoryMenuViewModel categoryMenuViewModel = new CategoryMenuViewModel
            {
                Categories = categoryMenuItems,
            };

            AllCategoriesViewModel AllCategories = new AllCategoriesViewModel
            {
                AllCategories = model,
                CategoryMenu = categoryMenuViewModel,
            };

            return AllCategories;
        }

        public AllCategoryCollectionViewModel GetAllCategoriesForAdmin()
        {
            IEnumerable<CategoryCollectionDetailsViewModel> model = dbContext.Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new CategoryCollectionDetailsViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImageUrl = imageService.GetImagePathByImageId(c.ImageId),
                })
                .ToList();


            AllCategoryCollectionViewModel allCategories = new AllCategoryCollectionViewModel
            {
                CategoryCollection = model,
            };

            return allCategories;
        }

        public List<SubCategoryDropDownMenuViewModel> GetSubCategoryDropDownItems()
        {
            var categoryDropDownMenuItems = dbContext
                .Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new SubCategoryDropDownMenuViewModel
                {
                    Text = c.CategoryName,
                    Value = c.Id.ToString()
                })
                .ToList();

            return categoryDropDownMenuItems;
        }

        public EditCategoryViewModel GetEditCategoryInfo(int categoryId)
        {
            EditCategoryViewModel model = dbContext.Categories
                .Where(c => !c.IsDeleted && c.Id == categoryId)
                .Select(c => new EditCategoryViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImagePath = imageService.GetImagePathByImageId(c.ImageId),
                })
                .FirstOrDefault();

            return model;
        }

        IEnumerable<CategoryDropDownMenuItemViewModel> ICategoriesService.GetCategoryDropDownItems()
        {
            IEnumerable<CategoryDropDownMenuItemViewModel> items = dbContext.Categories.
                Where(c => !c.IsDeleted)
                .Select(c => new CategoryDropDownMenuItemViewModel
                {
                    Text = c.CategoryName,
                    Value = c.Id.ToString(),
                })
                .ToList();

            return items;
        }

        public List<SubCategoryDropDownMenuViewModel> GetSubCategoryDropDownItems(int categoryId)
        {
            List<SubCategoryDropDownMenuViewModel> subCategoryItems = dbContext
                .SubCategories
                .Where(sc => !sc.IsDel && sc.CategoryId == categoryId)
                .Select(sc => new SubCategoryDropDownMenuViewModel
                {
                    Text = sc.SubCategoryName,
                    Value = sc.Id.ToString(),
                })
                .ToList();

            return subCategoryItems;

        }

        public CategorySubCategoryDetails CategoryDetails(int categoryId)
        {
            CategorySubCategoryDetails model = dbContext
                .Categories
                .Where(c => !c.IsDeleted && c.Id == categoryId)
                .Select(c => new CategorySubCategoryDetails
                {
                    CategoryName = c.CategoryName,
                    SubCategoryItems = c.SubCategories
                                        .Where(sb => !sb.IsDel && sb.CategoryId == c.Id)
                                        .Select(sb => new SubCategoryItemsViewModel
                                        {
                                            SubCategoryId = sb.Id,
                                            SubCategoryName = sb.SubCategoryName,
                                            Products = sb.Products
                                                          .Where(p => !p.IsDeleted && p.SubCategoryId == sb.Id)
                                                          .Select(p => new ProductsViewModel
                                                          {
                                                              Price = p.Price,
                                                              Color = p.Color.ColorName,
                                                              Description = p.Description,
                                                              ImagePath = imageService.GetImagePathByImageId(p.ImageId),
                                                              ProductId = p.Id,
                                                              ProductName = p.ProductName
                                                          }).ToList()

                                        }).ToList()
                }).FirstOrDefault();

            return model;
        }
    }
}
