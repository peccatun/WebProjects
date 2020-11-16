using System.Collections.Generic;

namespace FurnitureOnlineShop.ViewModels.Products
{
    public class AllProductsCollectionViewModel
    {
        public IEnumerable<AllProductsViewModel> AllProductsList { get; set; }

        public string CategoryName { get; set; }
    }
}
