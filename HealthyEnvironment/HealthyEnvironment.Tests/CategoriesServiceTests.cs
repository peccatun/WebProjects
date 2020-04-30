using CloudinaryDotNet;
using HealthyEnvironment.Data;
using HealthyEnvironment.Services.Categories;
using HealthyEnvironment.Services.Media;
using HealthyEnvironment.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HealthyEnvironment.Tests
{
    public class CategoriesServiceTests
    {
        [Fact]
        public void CreateCategoryAsyncTest()
        {
            var categoryService = this.initializeCategoriesService();

            var categories = categoryService.GetAllCategories();

            Assert.Empty(categories);
        }

        [Fact]
        public async Task CreateCategoryAsyncTestOne()
        {
            var db = this.initializeDbContext();
            var categoriesService = this.initializeCategoriesService();
            var fileMock = new Mock<IFormFile>();
            CreateCategoryViewModel model = new CreateCategoryViewModel
            {
                Image = fileMock.Object,
                Name = "Some name"
            };

            await categoriesService.CreateCategoryAsync(model);

            Assert.False(await db.Categories.AnyAsync());
        }

        [Fact]
        public void GetCategoryNameTest()
        {
            var categoriesService = this.initializeCategoriesService();
            string categoryName = categoriesService.GetCategoryName("some-id");
            Assert.Null(categoryName);
        }

        [Fact]
        public void GetCategoryNameAndId()
        {
            var categoriesService = this.initializeCategoriesService();

            var categoryDropDownList = categoriesService.GetCategoryNameAndId();

            Assert.Empty(categoryDropDownList);
        }

        private ApplicationDbContext initializeDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new ApplicationDbContext(options.Options);

            return dbContext;
        }

        private ICategoriesService initializeCategoriesService()
        {
            var db = this.initializeDbContext();
            var mediaService = new Mock<IMediaService>();
            var categoryService = new CategoriesService(db, mediaService.Object);

            return categoryService;
        }
    }
}
