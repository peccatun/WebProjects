using FurnitureOnlineShop.ViewModels.SubCategories;

namespace FurnitureOnlineShop.Services.SubCategories
{
    public interface ISubCategoryService
    {
        SubCategoryItemsViewModel GetSubCategoryItems(long subCategoryId);
    }
}
