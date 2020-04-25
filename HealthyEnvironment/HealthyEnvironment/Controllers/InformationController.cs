using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Comments;
using HealthyEnvironment.Services.Information;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Comments;
using HealthyEnvironment.ViewModels.Informations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyEnvironment.Controllers
{
    public class InformationController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IInformationService informationService;
        private readonly ICommentsService commentsService;

        public InformationController(
            ICategoriesService categoriesService,
            IInformationService informationService,
            ICommentsService commentsService)
        {
            this.categoriesService = categoriesService;
            this.informationService = informationService;
            this.commentsService = commentsService;
        }

        [HttpGet("/Information")]
        public IActionResult InformationHome()
        {
            InformationCategoriesViewModel model = new InformationCategoriesViewModel
            {
                informationCategories = informationService.GetInformationCategories(),
            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult CreateInformation()
        {
            var categories = categoriesService.GetCategoryNameAndId();
            CreateInfomationViewModel model = new CreateInfomationViewModel
            {
                Categories = categories,
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateInformationAsync(CreateInfomationViewModel model)
        {
            string applicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetCategoryNameAndId();
                return this.View(model);
            }
            await this.informationService.Create(model, applicationUserId);

            return this.Redirect("/Information");
        }

        public IActionResult InformationInCategory(string categoryId)
        {
            InformationInCategoryListViewModel model = new InformationInCategoryListViewModel
            {
                InformationInCategory = this.informationService.GetInformationInCategory(categoryId)
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult InformationDetails(string informationId)
        {
            if (!this.informationService.IsValidInformationId(informationId))
            {
                return StatusCode(404);
            }

            InformationDetailsViewModel model = this.informationService.GetInformationDetails(informationId);

            return this.View(model);
        }

        [Authorize]
        [HttpPost("/Information")]
        public async Task<IActionResult> CreateCommentAsync(CreateComentViewModel model)
        {
            string applicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.ApplicationUserId = applicationUserId;

            if (!ModelState.IsValid)
            {
                return this.View("InformationDetails", new { informationId = model.InformationId });
            }
            if (!await this.commentsService.CreateCommentAsync(model))
            {
                return this.StatusCode(404);
            }


            return this.RedirectToAction("InformationDetails","Information",new { informationId = model.InformationId });
        }
    }
}
