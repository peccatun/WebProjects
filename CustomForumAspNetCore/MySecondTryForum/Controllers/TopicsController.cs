using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecondTryForum.Services;
using MySecondTryForum.ViewModels.Topics;
using System.Collections.Generic;

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
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(OpenTopicViewModel input)
        {
            if (topicsService.HasOpenedTopic(input.Header))
            {
                return this.View("Error","There is an open topic with that header");
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

        //TODO: Create Go to topic Details 
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

        //TODO: Create Comments/All 
        //TODO: Create: Post a comment
        //TODO: Find a way to send the topic Id to the query!!!
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

        //TODO: Implement user open a topic, post comments ,etc...

    }
}
