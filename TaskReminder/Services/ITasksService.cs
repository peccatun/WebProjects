using System.Threading.Tasks;
using TaskReminder.InputModels;
using TaskReminder.ViewModels;

namespace TaskReminder.Services
{
    public interface ITasksService
    {
        UnfinishedTaskListViewModel GetUserUnfinishedTaskListById(string userId);

        bool IsValidUser(string userId);

        Task CreateTaskAsync(CreateTaskInputModel model);

        UnfinishedTaskDetailsViewModel GetUnfinishedTaskDetails(int taskId);

        EditUnfinishedTaskViewModel GetEditUnfinishedTask(int taskId);

        Task EditUnfinishedTaskByIdAsync(EditUnfinishedTaskInputModel model);

        Task DeleteTaskByIdAsync(int taskId);

        bool IsValidTask(int taskId);
    }
}
