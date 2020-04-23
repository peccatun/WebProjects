using System;
using System.Net;
using System.Text.RegularExpressions;

namespace HealthyEnvironment.ViewModels.Informations
{
    public class InformationInCategoryResumeViewModel
    {
        public string InformationId { get; set; }

        public string ImageUrl { get; set; }

        public string About { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorUserName { get; set; }

        public string ContentResume { get; set; }

        public string EscapeContentResume
        { 
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.ContentResume, @"<[^>]+>", string.Empty));

                return content;
            }
        }
    }
}
