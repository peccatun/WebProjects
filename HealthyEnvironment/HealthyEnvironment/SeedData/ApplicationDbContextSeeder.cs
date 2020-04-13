using HealthyEnvironment.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HealthyEnvironment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

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

            if (user!= null)
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
                };

                await dbContext.Categories.AddAsync(category);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
