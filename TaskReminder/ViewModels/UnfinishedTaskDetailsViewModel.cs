using System;

namespace TaskReminder.ViewModels
{
    public class UnfinishedTaskDetailsViewModel
    {
        public int TaskId { get; set; }

        public string Content { get; set; }

        public DateTime ExpireDay { get; set; }

        public bool IsCompleated { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
