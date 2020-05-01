using Ganss.XSS;
using HealthyEnvironment.ViewModels.Comments;
using System;
using System.Collections.Generic;

namespace HealthyEnvironment.ViewModels.Informations
{
    public class InformationDetailsViewModel
    {
        public string InformationId { get; set; }

        public string ImageUrl { get; set; }

        public string About { get; set; }

        public string CreatorUserName { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(Content);

        public string[] AdditionalImgUrls { get; set; }

        public IEnumerable<CommentDetailsViewModel> Comments { get; set; } = new HashSet<CommentDetailsViewModel>();
    }
}
