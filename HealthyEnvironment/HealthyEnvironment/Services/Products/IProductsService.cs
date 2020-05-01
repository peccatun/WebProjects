using HealthyEnvironment.ViewModels.Categories;
using HealthyEnvironment.ViewModels.Products;

namespace HealthyEnvironment.Services.Products
{
    public interface IProductsService
    {
        ProductListViewModel GetProductsList(string categoryId);

        ProductCategoryListViewModel GetProductCategories();

        ProductDetailsViewModel GetProductDetails(string productId);
    }
}
