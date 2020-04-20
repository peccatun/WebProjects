using System;

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
    }
}
