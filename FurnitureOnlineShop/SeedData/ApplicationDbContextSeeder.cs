using FurnitureOnlineShop.Data;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using FurnitureOnlineShop.Models;

namespace FurnitureOnlineShop.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
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

            var exists = dbContext.UserRoles.Any(ur => ur.RoleId == role.Id && ur.UserId == user.Id);

            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id,
            });

           await dbContext.SaveChangesAsync();
        }

        private async Task SeedRoleAsync()
        {
            var hasRole = dbContext.Roles.Any(r => r.Name == "Admin");

            if (hasRole)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin",
            });
        }

        private async Task SeedUserAsync()
        {
            var hasUser = dbContext.Users.Any(u => u.UserName == "Admin");

            if (hasUser)
            {
                return;
            }

            await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "Admin@abv.bg",
                    EmailConfirmed = true,
                    FirstName = "AdminFirstName",
                    LastName = "AdminLastName",
                },
                "Admin");
        }
    }
}
