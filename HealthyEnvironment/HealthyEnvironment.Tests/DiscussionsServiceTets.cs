using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Discussion;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.Services.Solutions;
using HealthyEnvironment.ViewModels.Discussions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HealthyEnvironment.Tests
{
    public class DiscussionsServiceTets
    {
        [Fact]
        public async Task CreateDiscussionAsyncTest()
        {
            var db = this.initializeDbContext();
            var discussionsService = this.initializeDiscussionsService(db);
            var imageMock = new Mock<IFormFile>();
            CreateDiscussionViewModel model = new CreateDiscussionViewModel
            {
                About = "About",
                AdditionalInfo = "Additional info maaaaaan",
                CategoryId = "some category id",
                Image = imageMock.Object,
            };
            string applicationUserId = "application";
            string discussionId = await discussionsService.CreateDiscussionAsync(model, applicationUserId);

            Assert.NotNull(discussionId);
        }

        [Fact]
        public void GetDiscussionCategories()
        {
            var db = this.initializeDbContext();
            var discussionsService = this.initializeDiscussionsService(db);

            var discussionCategories = discussionsService.GetDiscussionCategories();

            //I dont have categories in db to get from this method
            Assert.Empty(discussionCategories);
        }

        private ApplicationDbContext initializeDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new ApplicationDbContext(options.Options);
            dbContext.Discussions.Add(new Models.Discussion
            {
                About = "Something",
                AdditionalInfo = "Something again",
                ApplicationUserId = "Some applicationUserId",
                CategoryId = "this is categoryId",
                ImageUrl = "url",
                IsApproved = true,
                IsDeleted = false,
                OpenedOn = DateTime.UtcNow,
            });

            dbContext.SaveChanges();

            return dbContext;
        }

        private IDiscussionsService initializeDiscussionsService(ApplicationDbContext db)
        {
            var mediaService = new Mock<IMediaService>();
            var solutionsService = new Mock<ISolutionsService>();
            var discussionsService = new DiscussionsService(db, mediaService.Object, solutionsService.Object);

            return discussionsService;
        }
    }
}
