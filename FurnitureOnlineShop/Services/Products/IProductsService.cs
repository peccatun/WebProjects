using FurnitureOnlineShop.ViewModels.Products;

namespace FurnitureOnlineShop.Services.Products
{
    public interface IProductsService
    {
        AllProductsCollectionViewModel GetAllProductsInCategory(int categoryId);
    }
}
