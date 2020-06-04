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
    }
}
