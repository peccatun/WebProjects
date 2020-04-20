using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.ViewModels.Discussions;
using Microsoft.AspNetCore.Mvc;

namespace HealthyEnvironment.Controllers
{
    public class DiscussionsController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public DiscussionsController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet("/Discussions")]
        public IActionResult DiscussionsHome()
        {
            return this.View();
        }

        public IActionResult CreateDiscussion()
        {
            CreateDiscussionViewModel model = new CreateDiscussionViewModel
            {
                Categories = this.categoriesService.GetCategoryNameAndId(),
            };

            return this.View(model);
        }
    }
}
