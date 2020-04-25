using HealthyEnvironment.Services.Solutions;
using HealthyEnvironment.ViewModels.Solutions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyEnvironment.Controllers
{
    public class SolutionsController : Controller
    {
        private readonly ISolutionsService solutionsService;

        public SolutionsController(ISolutionsService solutionsService)
        {
            this.solutionsService = solutionsService;
        }

        [Authorize]
        [HttpPost("/Discussions")]
        public async Task<IActionResult> CreateSolutionAsync(CreateSolutionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("DiscussionDetails","Discussions", new { discussionId = model.DiscussionId});
            }

            model.ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(model.ApplicationUserId))
            {
                return this.BadRequest();
            }

            await this.solutionsService.CreateSolutionAsync(model);

            return this.RedirectToAction("DiscussionDetails", "Discussions", new { discussionId = model.DiscussionId});
        }
    }
}
