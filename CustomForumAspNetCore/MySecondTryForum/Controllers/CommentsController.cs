using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecondTryForum.Services;
using MySecondTryForum.ViewModels.Comments;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MySecondTryForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        public IActionResult AllComments(int topicId)
        {
            AllCommentsViewModel model = commentsService.TopicAllComents(topicId);

            return this.View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Reply(int id)
        {
            CommentReplyViewModel model = new CommentReplyViewModel()
            {
                TopicId = id
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Reply(CommentReplyViewModel input)
        {
            string userName = this.User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return this.View(input);
            }
            await commentsService.CreateCommentAsync(userName, input);

            return this.Redirect($"/Comments/AllComents?id={input.TopicId}");
        }

        //TODO: Implement Delete action!!!
        [Authorize]
        [HttpGet]
        public IActionResult Delete(DeleteCommentViewModel model)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!commentsService.Delete(currentUserId,model.CommentId))
            {
                return this.View("DeleteErrorView", "You can't delete this comment");
            }

            return this.RedirectToAction($"AllComments", new { @topicId = model.TopicId });
        }
    }
}
