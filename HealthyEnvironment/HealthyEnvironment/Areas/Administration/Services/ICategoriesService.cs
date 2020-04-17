using HealthyEnvironment.Areas.Administration.ViewModels.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> GetAllCategories();

        CategoryDetailsViewModel GetCategoryDetails(string categoryId);

        Task UpdateCategoryAsync(CategoryDetailsViewModel model);
    }
}
