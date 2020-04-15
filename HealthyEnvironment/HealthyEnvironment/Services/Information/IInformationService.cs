using HealthyEnvironment.ViewModels.Informations;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Information
{
    public interface IInformationService
    {
        Task Create(CreateInfomationViewModel model, string applicationUserId);
    }
}
