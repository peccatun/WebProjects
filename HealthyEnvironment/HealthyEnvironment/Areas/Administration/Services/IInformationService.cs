using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using System.Collections.Generic;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public interface IInformationService
    {
        IEnumerable<InformationViewModel> GetAllInformation();
    }
}
