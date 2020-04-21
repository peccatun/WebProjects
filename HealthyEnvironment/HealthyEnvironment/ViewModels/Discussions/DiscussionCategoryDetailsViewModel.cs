using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class DiscussionCategoryDetailsViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public int DiscussionsCount { get; set; }
    }
}
