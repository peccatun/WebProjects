using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class DiscussionsInCategoryDetailViewModel
    {
        public string DiscussionId { get; set; }

        public string CreatorName { get; set; }

        public string CategoryName { get; set; }

        public string About { get; set; }

        public string ImageUrl { get; set; }

        public string AdditionalInfo { get; set; }

        public string AdditionalInfoEscape
        {
            get
            {
                var content =  WebUtility.HtmlDecode(Regex.Replace(this.AdditionalInfo, @"<[^>]+>", string.Empty));

                return content;
            }
        }

        public DateTime CreatedOn { get; set; }

        public int SolutionsCount { get; set; }
    }
}
