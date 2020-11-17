using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.ViewModels.Categories;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Categories
{
    public interface ICategoriesService
    {
        AllCategoriesViewModel GetAllCategories();

        Task CreateCategoryAsync(CreateCategoryInputModel input);
    }
}
