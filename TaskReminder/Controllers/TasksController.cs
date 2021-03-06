﻿using Microsoft.AspNetCore.Mvc;
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
            model.ExpireDay = DateTime.UtcNow;
            model.ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return this.View(model);
        }

        public async Task<IActionResult> DeleteTaskById(int taskId)
        {
            if (!this.tasksService.IsValidTask(taskId))
            {
                return this.RedirectToAction("UserUnfinishedTasks");
            }

            await this.tasksService.DeleteTaskByIdAsync(taskId);

            return this.RedirectToAction("UserUnfinishedTasks");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateTaskInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!tasksService.IsValidUser(model.ApplicationUserId))
            {
                return this.View(model);
            }

            await tasksService.CreateTaskAsync(model);

            return this.RedirectToAction("UserUnfinishedTasks");
        }

        public IActionResult UserUnfinishedTasks()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            UnfinishedTaskListViewModel model = tasksService.GetUserUnfinishedTaskListById(userId);
            if (model.UnfinishedTasks.Count() == 0)
            {
                return this.View("UserWithNoTasks");
            }

            return this.View(model);
        }

        public IActionResult UnfinishedTaskDetails(int taskId)
        {
            UnfinishedTaskDetailsViewModel model = this.tasksService.GetUnfinishedTaskDetails(taskId);
            if (model == null)
            {
                return this.RedirectToAction("UserUnfinishedTasks");
            }
            return this.View(model);
        }

        public IActionResult EditUnfinishedTask(int taskId)
        {
            EditUnfinishedTaskViewModel model = this.tasksService.GetEditUnfinishedTask(taskId);
            if (model == null)
            {
                return this.RedirectToAction("UserUnfinishedTasks");
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUnfinishedTaskAsync(EditUnfinishedTaskInputModel model)
        {
            await this.tasksService.EditUnfinishedTaskByIdAsync(model);
            return this.RedirectToAction("UnfinishedTaskDetails", new { taskId = model.TaskId });
        }
    }
}
