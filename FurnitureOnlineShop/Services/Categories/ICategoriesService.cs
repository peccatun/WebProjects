﻿using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.ViewModels.Categories;
using FurnitureOnlineShop.ViewModels.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Categories
{
    public interface ICategoriesService
    {
        AllCategoriesViewModel GetAllCategories();

        Task CreateCategoryAsync(CreateCategoryInputModel input);

        AllCategoryCollectionViewModel GetAllCategoriesForAdmin();

        EditCategoryViewModel GetEditCategoryInfo(int categoryId);

        Task DeleteCategoryByIdAsync(int categoryId);

        List<CategoryDropDownMenuViewModel> GetCategoryDropDownItems();
    }
}
