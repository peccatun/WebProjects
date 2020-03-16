using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecondTryForum.Services;
using MySecondTryForum.ViewModels.Topics;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MySecondTryForum.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicsService topicsService;

        public TopicsController(ITopicsService topicsService)
        {
            this.topicsService = topicsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            OpenTopicViewModel model = new OpenTopicViewModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(OpenTopicViewModel input)
        {
            if (topicsService.HasOpenedTopic(input.Header))
            {
                return this.View("Error","There is an open topic with that header");
            }

            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            string applicationUserName = this.User.Identity.Name;
            CreateTopicViewModel model = new CreateTopicViewModel
            {
                AppUserName = applicationUserName,
                Header = input.Header,
            };

            int topicId = topicsService.CreateTopic(model);
            
            return this.Redirect($"/Topics/Details?id={topicId}");
        }

        [HttpGet]
        public IActionResult All()
        {
            IEnumerable<TopicDetailsViewModel> allTopics = topicsService.AllTopics();
            AllTopicsViewModel model = new AllTopicsViewModel
            {
                Topics = allTopics,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!topicsService.HasTopic(id))
            {
                return this.View("Error", "Invalid topic");
            }

            TopicDetailsViewModel model = topicsService.TopicDetails(id);

            return this.View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int topicId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!topicsService.Delete(userId,topicId))
            {
                return this.View("/Views/Comments/DeleteErrorView.cshtml", "You can't delete this topic!!!");
            }

            return this.RedirectToAction("All");
        }

    }
}
