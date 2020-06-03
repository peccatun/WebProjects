using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskReminder.InputModels;
using TaskReminder.Services;
using TaskReminder.ViewModels;

namespace TaskReminder.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            CreateTaskInputModel model = new CreateTaskInputModel();
            return this.View(model);
        }

        public IActionResult UserUnfinishedTasks()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            UnfinishedTaskListViewModel model = tasksService.GetUserUnfinishedTaskListById(userId);
            if (model.UnfinishedTasks.Count() == 0)
            {
                return this.View("UserWithNoTasks");
            }

            return this.View();
        }
    }
}
