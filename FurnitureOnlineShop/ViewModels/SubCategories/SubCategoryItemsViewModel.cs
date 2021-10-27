using FurnitureOnlineShop.ViewModels.Products;
using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.SubCategories
{
    public class SubCategoryItemsViewModel
    {
        public string SubCategoryName { get; set; }

        public IEnumerable<ProductsViewModel> Products { get; set; } = new HashSet<ProductsViewModel>();
    }
}
