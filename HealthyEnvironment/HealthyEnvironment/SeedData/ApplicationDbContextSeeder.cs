using HealthyEnvironment.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HealthyEnvironment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HealthyEnvironment.SeedData
{
    

    public class ApplicationDbContextSeeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
        }

        public async Task SeedDataAsync()
        {
            await SeedUserAsync();
            await SeedRoleAsync();
            await SeedUserToRoleAsync();
            await SeedCategoriesAsync();
            await SeedInformationAsync();
            await SeedDiscussionAsync();
            await SeedSolutionsAsync();
        }

        private async Task SeedUserToRoleAsync()
        {
            var user = await userManager.FindByNameAsync("Admin");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedRoleAsync()
        {
            var role = roleManager.FindByNameAsync("Admin");

            if (role.Result != null)
            {
                return;
            }

            var newRole = new IdentityRole()
            {
                Name = "Admin"

            };

            await roleManager.CreateAsync(newRole);

        }

        private async Task SeedUserAsync()
        {
            var user = await userManager.FindByNameAsync("Admin");

            if (user != null)
            {
                return;
            }

            var result = await userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "HealthyEnviromentAdmin@abv.bg"
            },
            "admin");
        }

        private async Task SeedCategoriesAsync()
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            List<string> categories = new List<string>
            {
                "Fruit-Trees",
                "Fertiliser",
                "GlobalProblems",
                "HealthyLife",
                "Environment",
                "Science % Math",
                "Random",
            };

            List<string> imageUrl = new List<string>
            {
                "https://previews.123rf.com/images/genestro/genestro1808/genestro180800043/111635070-fruit-trees-set-cartoon-images-of-garden-berries-vector-illustration.jpg",
                "https://www.fertilizer-machine.net/wp-content/uploads/2018/06/types-of-fertilizer.jpg",
                "https://c8.alamy.com/comp/WXYJBD/earth-with-deforestation-and-global-warming-problems-illustration-WXYJBD.jpg",
                "https://healthsourcechiro.azureedge.net/media/2079/healthy-life.jpg?v636320193720000000",
                "https://pbs.twimg.com/media/ESLn_4oXYAA3vCz.jpg",
                "https://thumbs.dreamstime.com/z/open-book-has-various-math-science-space-concepts-coming-out-school-learning-concept-29798040.jpg",
                "https://miro.medium.com/max/5000/1*1BUIofZgqVuR6nj8LbrRtQ.jpeg",
            };

            for (int i = 0; i < 7; i++)
            {
                Category category = new Category
                {
                    Name = categories[i],
                    IsApproved = true,
                    ImageUrl = imageUrl[i],
                    IsDeleted = false,
                    CreateOn = DateTime.UtcNow,
                };

                await dbContext.Categories.AddAsync(category);
            }

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedInformationAsync()
        {
            if (dbContext.Information.Any())
            {
                return;
            }

            List<string> seedCategories = new List<string>
            {
               "Science % Math",
                "Random",
            };

            var user = await userManager.FindByNameAsync("Admin");
            string imageUrl = "https://us.123rf.com/450wm/pavelstasevich/pavelstasevich1811/pavelstasevich181101065/112815953-stock-vector-no-image-available-icon-flat-vector.jpg?ver=6";

            foreach (var category in seedCategories)
            {
                string categoryId = this.dbContext
                    .Categories
                    .Where(c => c.Name == category)
                    .Select(c => c.Id)
                    .FirstOrDefault();


                for (int i = 0; i < 4; i++)
                {
                    Information information = new Information
                    {
                        About = $"TestInformationCategory {category} {i}",
                        ApplicationUserId = user.Id,
                        CategoryId = categoryId,
                        ImageUrl = imageUrl,
                        CreatedOn = DateTime.UtcNow,
                        IsApproved = true,
                        IsDeleted = false,
                        Content = $"TestInformationCategory {category} {i} TestInformationCategory{category} {i} TestInformationCategory {category} {i}",
                    };

                    await dbContext.Information.AddAsync(information);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedDiscussionAsync()
        {
            if (dbContext.Discussions.Any())
            {
                return;
            }


            string[] categories = { "Random", "GlobalProblems" };
            var user = await userManager.FindByNameAsync("Admin");
            int imageUrlContainerIndex = 0;

            for (int i = 0; i < 2; i++)
            {
                string categoryId = dbContext.Categories.Where(c => c.Name == categories[i]).Select(c => c.Id).FirstOrDefault();

                for (int j = 0; j < 6; j++)
                {
                    string additionalInfo = DiscussionAdditInfoGenerator(j);
                    string imageUrl = ImageUrlContainer(imageUrlContainerIndex);
                    imageUrlContainerIndex++;
                    Discussion discussion = new Discussion
                    {
                        About = $"Test discussion about {j}",
                        AdditionalInfo = additionalInfo,
                        ApplicationUserId = user.Id,
                        OpenedOn = DateTime.UtcNow,
                        IsApproved = true,
                        IsDeleted = false,
                        CategoryId = categoryId,
                        ImageUrl = imageUrl,
                    };

                    await dbContext.Discussions.AddAsync(discussion);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedSolutionsAsync()
        {
            if (dbContext.Solutions.Any())
            {
                return;
            }

            var user = await userManager.FindByNameAsync("Admin");
            string applicationUserId = user.Id;
            string content = SolutionContentGenerator();
            string imageUrl = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                string discussionId = DiscussionIdsContainer(i);

                for (int j = 0; j < 6; j++)
                {
                    imageUrl = null;

                    if (j % 2 == 0)
                    {
                        imageUrl = ImageUrlContainer(j);
                    }

                    Solution solution = new Solution
                    {
                        IsDeleted = false,
                        PostedOn = DateTime.UtcNow,
                        DiscussionId = discussionId,
                        ApplicationUserId = applicationUserId,
                        Content = content,
                        ImageUrl = imageUrl,
                    };

                    await dbContext.Solutions.AddAsync(solution);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private string DiscussionAdditInfoGenerator(int j)
        {
            StringBuilder additionalInfoResult = new StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                additionalInfoResult.Append($"This is random Additional info from seed generator with i = {i} and j= {j}");
            }

            return additionalInfoResult.ToString();
        }

        private string ImageUrlContainer(int i)
        {
            string[] imageUrls =
            {
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587577825/vf6pkzwwjpheibmgbis3.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587576286/ztfsbn7sukng0ombdu39.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1586710824/sample.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587296025/oqq0vwuxjzs9pttp6sdx.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587488018/mscb8r6gpelxyvl1qekg.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587577879/vaymqsjt71xcwee9qpez.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587662437/qfamzcghcujosq9fcegu.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587746253/c3ww2oatouyeyvnssrih.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587810238/wzzd91u3epa7bsseko4p.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587820875/c3ldaby59rid3vzm7ta3.png",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587819055/yuwmfi39j5ymq1upqobl.jpg",
                "https://res.cloudinary.com/dgdburirj/image/upload/v1587491391/i3ybreg5trff0j3zvb5e.jpg",

            };

            return imageUrls[i];
        }

        private string DiscussionIdsContainer(int i)
        {
            string[] discussionIds = dbContext
                .Discussions
                .Select(d => d.Id)
                .ToArray();

            return discussionIds[i];
        }

        private string SolutionContentGenerator()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sb.Append($"The solution content is generated from the seed method SolutionContentGenerator with index {i} ");
            }

            return sb.ToString();
        }
    }
}
