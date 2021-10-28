using FurnitureOnlineShop.Areas.Administration.InputModels.Products;
using FurnitureOnlineShop.ViewModels.Products;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Products
{
    public interface IProductsService
    {
        AllProductsCollectionViewModel GetAllProductsInCategory(int categoryId);

        Task InsertProduct(CreateProductInputModel inputModel);

        ProductDetailsViewModel ProductDetails(int id);
    }
}
