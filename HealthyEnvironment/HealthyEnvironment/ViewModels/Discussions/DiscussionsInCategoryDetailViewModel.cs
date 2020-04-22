using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class DiscussionsInCategoryDetailViewModel
    {
        public string DiscussionId { get; set; }

        public string CategoryName { get; set; }

        public string About { get; set; }

        public string ImageUrl { get; set; }

        public string AdditionalInfo { get; set; }

        public DateTime CreatedOn { get; set; }

        public int SolutionsCount{ get; set; }
    }
}
