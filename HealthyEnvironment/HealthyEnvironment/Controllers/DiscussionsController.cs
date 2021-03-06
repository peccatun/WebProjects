﻿using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Discussion;
using HealthyEnvironment.Services.Solutions;
using HealthyEnvironment.ViewModels.Discussions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyEnvironment.Controllers
{
    public class DiscussionsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDiscussionsService discussionsService;
        private readonly ISolutionsService solutionsService;

        public DiscussionsController(
            ICategoriesService categoriesService, 
            IDiscussionsService discussionsService,
            ISolutionsService solutionsService  
            )
        {
            this.categoriesService = categoriesService;
            this.discussionsService = discussionsService;
            this.solutionsService = solutionsService;
        }

        [HttpGet("/Discussions")]
        public IActionResult DiscussionsHome()
        {
            DisplayDiscussionCategoriesViewModel model = new DisplayDiscussionCategoriesViewModel
            {
                Discussions = this.discussionsService.GetDiscussionCategories(),
            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult CreateDiscussion()
        {
            CreateDiscussionViewModel model = new CreateDiscussionViewModel
            {
                Categories = this.categoriesService.GetCategoryNameAndId(),
            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult CreateDiscussionInCategory(string categoryId)
        {
            CreateDiscussionViewModel model = new CreateDiscussionViewModel()
            {
                Categories = this.categoriesService.GetCategoryNameAndId(),
                CategoryId = categoryId,
            };

            return this.View("CreateDiscussion", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDiscussionAsync(CreateDiscussionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetCategoryNameAndId();
                return this.View(model);
            }

            string applicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string discussionId = await this.discussionsService.CreateDiscussionAsync(model, applicationUserId);

            return this.RedirectToAction("DiscussionDetails", "Discussions", new { discussionId });
        }

        public IActionResult DiscussionsInCategory(string categoryId)
        {
            DiscussionsInCategoryListViewModel model = new DiscussionsInCategoryListViewModel
            {
                Discussions = this.discussionsService.GetDiscussionsInCategory(categoryId),
                CategoryName = this.categoriesService.GetCategoryName(categoryId),
                CategoryId = categoryId,
            };

            return this.View(model);
        }

        public IActionResult DiscussionDetails(string discussionId)
        {
            DiscussionDetailsViewModel model = this.discussionsService.GetDiscussionDetails(discussionId);

            return this.View(model);
        }
    }
}
