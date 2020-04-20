using System;

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
    }
}
