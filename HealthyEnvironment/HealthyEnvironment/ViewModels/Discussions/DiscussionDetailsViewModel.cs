﻿using Ganss.XSS;
using HealthyEnvironment.ViewModels.Solutions;
using System;
using System.Collections.Generic;

namespace HealthyEnvironment.ViewModels.Discussions
{
    public class DiscussionDetailsViewModel
    {
        public string DiscussionId { get; set; }

        public string About { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public string CreatorName { get; set; }

        public string AdditionalInfo { get; set; }

        public string SanitizedAdditionalInfo => new HtmlSanitizer().Sanitize(AdditionalInfo);

        public CreateSolutionViewModel CreateSolutionModel { get; set; }

        public IEnumerable<SolutionDetailsViewModel> DiscussionSolutions { get; set; }
    }
}
