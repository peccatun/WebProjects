using Ganss.XSS;
using System;

namespace HealthyEnvironment.Areas.Administration.ViewModels.Information
{
    public class InformationDetailsViewModel
    {
        public string InformationId { get; set; }

        public string CreatorUserName { get; set; }

        public string ImageUrl { get; set; }

        public string About { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(Content);

        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public string[] AdditionalImgUrls { get; set; }
    }
}
