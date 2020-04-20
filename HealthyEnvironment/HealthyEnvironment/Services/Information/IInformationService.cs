using HealthyEnvironment.ViewModels.Informations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Information
{
    public interface IInformationService
    {
        Task Create(CreateInfomationViewModel model, string applicationUserId);

        IEnumerable<InformationCategoryDetailsViewModel> GetInformationCategories();

        IEnumerable<InformationInCategoryResumeViewModel> GetInformationInCategory(string categoryId);

        InformationDetailsViewModel GetInformationDetails(string informationId);

        bool IsValidInformationId(string informationId);
    }
}
