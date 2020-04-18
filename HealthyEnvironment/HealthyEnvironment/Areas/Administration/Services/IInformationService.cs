using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public interface IInformationService
    {
        IEnumerable<InformationViewModel> GetAllInformation();

        InformationDetailsViewModel GetInformationById(string informationId);

        Task UpdateInformation(UpdateInformationViewModel model);
    }
}
