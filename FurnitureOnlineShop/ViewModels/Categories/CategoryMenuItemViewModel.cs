
using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.Categories
{
    public class CategoryMenuItemViewModel
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SubCategoryMenuItemViewModel> SubCategories { get; set; }
    }
}
