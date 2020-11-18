using System.Collections.Generic;

namespace FurnitureOnlineShop.Areas.Administration.ViewModels.Categories
{
    public class AllCategoryCollectionViewModel
    {
        public IEnumerable<CategoryCollectionDetailsViewModel> CategoryCollection { get; set; }
    }
}
