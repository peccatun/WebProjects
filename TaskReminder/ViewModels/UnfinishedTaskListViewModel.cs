using System.Collections.Generic;

namespace TaskReminder.ViewModels
{
    public class UnfinishedTaskListViewModel
    {
        public IEnumerable<UnfinishedTaskViewModel> UnfinishedTasks { get; set; }
    }
}
