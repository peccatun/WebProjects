using TaskReminder.ViewModels;

namespace TaskReminder.Services
{
    public interface ITasksService
    {
        UnfinishedTaskListViewModel GetUserUnfinishedTaskListById(string userId);
    }
}
