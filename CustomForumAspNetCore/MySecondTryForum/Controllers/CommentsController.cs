using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecondTryForum.Services;
using MySecondTryForum.ViewModels.Comments;
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
        public IActionResult AllComents(int id)
        {
            AllCommentsViewModel model = commentsService.TopicAllComents(id);

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
    }
}
