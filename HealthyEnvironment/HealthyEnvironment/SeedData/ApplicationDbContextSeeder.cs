using HealthyEnvironment.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HealthyEnvironment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

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

            if (role != null)
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
    }
}
