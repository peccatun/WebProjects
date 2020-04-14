using HealthyEnvironment.ViewModels.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Categories
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> GetAllCategories();

        Task CreateCategoryAsync(CreateCategoryViewModel model);

        IEnumerable<CategoryDropDownViewModel> GetCategoryNameInfo();
    }
}
