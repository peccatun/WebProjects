using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Discussion;
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

        public DiscussionsController(
            ICategoriesService categoriesService, 
            IDiscussionsService discussionsService
            )
        {
            this.categoriesService = categoriesService;
            this.discussionsService = discussionsService;
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
        [HttpPost]
        public async Task<IActionResult> CreateDiscussion(CreateDiscussionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetCategoryNameAndId();
                return this.View(model);
            }

            string applicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.discussionsService.CreateDiscussionAsync(model, applicationUserId);

            return this.Redirect("/Discussions");
        }

        public IActionResult DiscussionsInCategory(string categoryId)
        {
            DiscussionsInCategoryListViewModel model = new DiscussionsInCategoryListViewModel
            {
                Discussions = this.discussionsService.GetDiscussionsInCategory(categoryId),
                CategoryName = this.categoriesService.GetCategoryName(categoryId),
            };

            return this.View(model);
        }

        public IActionResult DiscussionDetails(string discussionId)
        {
            return this.View();
        }
    }
}
