﻿using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.ViewModels.Categories;
using FurnitureOnlineShop.Data;
using FurnitureOnlineShop.Models;
using FurnitureOnlineShop.Services.CategoryImages;
using FurnitureOnlineShop.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryImageService categoryImageService;

        public CategoriesService(ApplicationDbContext dbContext, ICategoryImageService categoryImageService)
        {
            this.dbContext = dbContext;
            this.categoryImageService = categoryImageService;
        }

        public async Task CreateCategoryAsync(CreateCategoryInputModel input)
        {
            int categoryImageId = await categoryImageService.SaveCategoryImageToDb(input.Image);

            Category category = new Category
            {
                CategoryName = input.CategoryName,
                Description = input.Description,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                CategoryImageId = categoryImageId,
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
                int categoryImageId = categoryToDelete.CategoryImageId;
                await categoryImageService.DeleteCategoryImageByIdAsync(categoryImageId);

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
                    ImagePath = categoryImageService.GetImagePathByImageId(c.CategoryImageId),
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
                    ImageUrl = categoryImageService.GetImagePathByImageId(c.CategoryImageId),
                })
                .ToList();


            AllCategoryCollectionViewModel allCategories = new AllCategoryCollectionViewModel
            {
                CategoryCollection = model,
            };

            return allCategories;
        }

        public List<SubCategoryDropDownMenuViewModel> GetCategoryDropDownItems()
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
                    ImagePath = categoryImageService.GetImagePathByImageId(c.CategoryImageId),
                })
                .FirstOrDefault();

            return model;
        }
    }
}
