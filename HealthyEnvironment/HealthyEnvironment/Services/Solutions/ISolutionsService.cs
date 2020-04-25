using HealthyEnvironment.ViewModels.Solutions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Solutions
{
    public interface ISolutionsService
    {
        Task CreateSolutionAsync(CreateSolutionViewModel model);
        IEnumerable<SolutionDetailsViewModel> GetDiscussionSolutons(string discussionId);
    }
}
