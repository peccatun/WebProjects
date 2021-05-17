using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.Categories
{
    public class CategoryDetailsViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<SubCategoryMenuItemViewModel> SubCategories { get; set; } = new HashSet<SubCategoryMenuItemViewModel>();
    }
}
