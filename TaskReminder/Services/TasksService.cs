using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskReminder.Data;
using TaskReminder.InputModels;
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

        public async Task CreateTaskAsync(CreateTaskInputModel model)
        {
            Models.Task task = new Models.Task
            {
                ApplicationUserId = model.ApplicationUserId,
                Content = model.Content,
                ExpireDay = model.ExpireDay,
                IsCompleated = false,
            };

            await db.Tasks.AddAsync(task);
            await db.SaveChangesAsync();
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

        public bool IsValidUser(string userId)
        {
            return this.db.Users.Any(u => u.Id == userId);
        }
    }
}
