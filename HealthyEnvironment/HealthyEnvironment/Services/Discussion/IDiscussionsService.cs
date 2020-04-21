using HealthyEnvironment.ViewModels.Discussions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Discussion
{
    public interface IDiscussionsService
    {
        Task CreateDiscussionAsync(CreateDiscussionViewModel model, string applicationUserId);

        IEnumerable<DiscussionDetailViewModel> GetDiscussionsInCategory(string categoryId);

        IEnumerable<DiscussionCategoryDetailsViewModel> GetDiscussionCategories();
    }
}
