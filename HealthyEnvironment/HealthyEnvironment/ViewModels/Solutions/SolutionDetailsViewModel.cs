using Ganss.XSS;
using System;

namespace HealthyEnvironment.ViewModels.Solutions
{
    public class SolutionDetailsViewModel
    {
        public string CreatorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(Content);

        public string ImageUrl { get; set; }
    }
}
