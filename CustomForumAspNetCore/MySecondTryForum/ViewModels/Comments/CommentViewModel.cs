using System;

namespace MySecondTryForum.ViewModels.Comments
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Username { get; set; }

        public DateTime PostedOn { get; set; }

        public string ImagePath { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
