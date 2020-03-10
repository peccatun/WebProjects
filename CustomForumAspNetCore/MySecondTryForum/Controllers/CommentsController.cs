using Microsoft.AspNetCore.Mvc;
using System;

namespace MySecondTryForum.Controllers
{
    public class CommentsController : Controller
    {
        //TODO: Create comments service

        [HttpGet]
        public IActionResult AllComents(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Reply(int id)
        {
            return this.View();
        }
    }
}
