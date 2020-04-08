using HealthyEnvironment.ViewModels.Categories;
using System.Collections.Generic;

namespace HealthyEnvironment.Services.Categories
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> GetAllCategories();
    }
}
