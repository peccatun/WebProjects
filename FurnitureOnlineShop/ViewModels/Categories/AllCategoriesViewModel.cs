using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.Categories
{
    public class AllCategoriesViewModel
    {
        public IEnumerable<CategoryDetailsViewModel> AllCategories { get; set; }

        public CategoryMenuViewModel CategoryMenu { get; set; }
    }
}
