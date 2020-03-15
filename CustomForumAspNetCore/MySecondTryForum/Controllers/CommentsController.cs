using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecondTryForum.Services;
using MySecondTryForum.ViewModels.Comments;
using System;

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
            //TODO Implement View and Create ViewModel for AllComments
            AllCommentsViewModel model = commentsService.TopicAllComents(id);
            return this.View(model);
        }

        //TODO: authorize your actions!
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
        public IActionResult Reply(CommentReplyViewModel input)
        {
            string userName = this.User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return this.View(input);
            }
            commentsService.CreateComment(userName, input);

            return this.Redirect($"/Comments/AllComents?id={input.TopicId}");
        }
    }
}
