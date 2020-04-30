using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Comments;
using HealthyEnvironment.ViewModels.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HealthyEnvironment.Tests
{
    public class CommentsServiceTests
    {
        [Fact]
        public async Task CreateCommentTest()
        {
            var db = this.initializeDbContext();
            var commentsService = new CommentsService(db);

            CreateComentViewModel model = new CreateComentViewModel
            {
                ApplicationUserId = "This is some id",
                InformationId = "This is some id",
                Content = "This is some contet",
            };

            await commentsService.CreateCommentAsync(model);

            Assert.False(await db.Comments.AnyAsync());
        }

        [Fact]
        public void GetCommentDetailsTest()
        {
            var db = this.initializeDbContext();
            var commentService = new CommentsService(db);
            var comment = commentService.GetCommentDetails("someInformationId");

            Assert.Empty(comment);
        }

        private ApplicationDbContext initializeDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new ApplicationDbContext(options.Options);

            return dbContext;
        }
    }
}
