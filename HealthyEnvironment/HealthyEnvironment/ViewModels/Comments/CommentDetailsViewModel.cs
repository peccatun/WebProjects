using System;

namespace HealthyEnvironment.ViewModels.Comments
{
    public class CommentDetailsViewModel
    {
        public string CreatorUserName { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
