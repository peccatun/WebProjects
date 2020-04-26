using HealthyEnvironment.Areas.Administration.ViewModels.Products;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public interface IProductsServiceAdmin
    {
        Task CreateProductAsync(CreateProductViewModel model);
    }
}
