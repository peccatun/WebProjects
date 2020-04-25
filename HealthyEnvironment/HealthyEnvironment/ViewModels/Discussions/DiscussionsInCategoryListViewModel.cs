using System.Collections.Generic;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class DiscussionsInCategoryListViewModel
    {
        public IEnumerable<DiscussionsInCategoryDetailViewModel> Discussions { get; set; }

        public string CategoryName { get; set; }

        public string CategoryId { get; set; }
    }
}
