using System.Collections.Generic;
using System.Linq;
using TaskReminder.Data;
using TaskReminder.ViewModels;

namespace TaskReminder.Services
{
    public class TasksService : ITasksService
    {
        private readonly ApplicationDbContext db;

        public TasksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public UnfinishedTaskListViewModel GetUserUnfinishedTaskListById(string userId)
        {
            IEnumerable<UnfinishedTaskViewModel> unfinishedTaskList = db.Tasks
                .Where(u => u.ApplicationUserId == userId)
                .Where(t => !t.IsCompleated)
                .Select(t => new UnfinishedTaskViewModel
                {
                    TaskId = t.Id,
                    Content = t.Content,
                    IsCompleated = t.IsCompleated,
                    ApplicationUserId = t.ApplicationUserId,
                    ExpireDay = t.ExpireDay,
                })
                .ToList();

            UnfinishedTaskListViewModel unfinishedTaskListModel = new UnfinishedTaskListViewModel
            {
                UnfinishedTasks = unfinishedTaskList,
            };

            return unfinishedTaskListModel;
        }
    }
}
