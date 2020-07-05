using System;
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
            DateTime taskExpireDateTime = model.ExpireDay.Date.Add(model.ExpireTime.TimeOfDay);

            Models.Task task = new Models.Task
            {
                ApplicationUserId = model.ApplicationUserId,
                Content = model.Content,
                ExpireDay = taskExpireDateTime,
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

        public UnfinishedTaskDetailsViewModel GetUnfinishedTaskDetails(int taskId)
        {
            UnfinishedTaskDetailsViewModel model = this.db.Tasks
                .Where(t => t.Id == taskId)
                .Select(t => new UnfinishedTaskDetailsViewModel
                {
                    ApplicationUserId = t.ApplicationUserId,
                    Content = t.Content,
                    ExpireDay = t.ExpireDay,
                    IsCompleated = t.IsCompleated,
                    TaskId = taskId
                })
                .FirstOrDefault();

            return model;
        }

        public EditUnfinishedTaskViewModel GetEditUnfinishedTask(int taskId)
        {
            EditUnfinishedTaskViewModel model = this.db.Tasks
                .Where(t => t.Id == taskId)
                .Select(t => new EditUnfinishedTaskViewModel
                {
                    TaskId = t.Id,
                    Content = t.Content,
                    ExpireDate = t.ExpireDay,
                    ExpireTime = t.ExpireDay,
                })
                .FirstOrDefault();

            return model;
        }

        public async Task EditUnfinishedTaskByIdAsync(EditUnfinishedTaskInputModel model)
        {
            var task = this.db.Tasks.FirstOrDefault(t => t.Id == model.TaskId);

            if (task == null)
            {
                return;
            }

            DateTime combinedDateTime = model.ExpireDate.Date.Add(model.ExpireTime.TimeOfDay);

            task.Content = model.Content;
            task.ExpireDay = combinedDateTime;

            await db.SaveChangesAsync();
        }
    }
}
