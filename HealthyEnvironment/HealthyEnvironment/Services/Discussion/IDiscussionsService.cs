using HealthyEnvironment.ViewModels.Discussions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Discussion
{
    public interface IDiscussionsService
    {
        Task<string> CreateDiscussionAsync(CreateDiscussionViewModel model, string applicationUserId);

        IEnumerable<DiscussionsInCategoryDetailViewModel> GetDiscussionsInCategory(string categoryId);

        IEnumerable<DiscussionCategoryDetailsViewModel> GetDiscussionCategories();

        DiscussionDetailsViewModel GetDiscussionDetails(string discussionId);
    }
}
