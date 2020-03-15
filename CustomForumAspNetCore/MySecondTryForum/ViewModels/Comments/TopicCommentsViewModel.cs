using System;
using System.Collections.Generic;

namespace MySecondTryForum.ViewModels.Comments
{
    public class TopicCommentsViewModel
    {
        public int TopicId { get; set; }

        public string Header { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
