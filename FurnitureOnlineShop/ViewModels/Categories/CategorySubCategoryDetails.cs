using FurnitureOnlineShop.ViewModels.SubCategories;
using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.Categories
{
    public class CategorySubCategoryDetails
    {
        public string CategoryName { get; set; }

        public List<SubCategoryItemsViewModel> SubCategoryItems { get; set; }
    }
}
