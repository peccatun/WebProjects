using MotMaintOnline4.Data;
using MotMaintOnline4.ViewModels.ApplicationUser;
using MotMaintOnline4.InputModels.ApplicationUser;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MotMaintOnline4.Services.ApplicationUser
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationUserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(ApplicationUserInputModel inputModel)
        {
            Models.ApplicationUser applicationUser = new Models.ApplicationUser
            {
                IsDel = false,
                Name = inputModel.Name,
            };

            await dbContext.ApplicationUsers.AddAsync(applicationUser);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Models.ApplicationUser user = dbContext
                .ApplicationUsers
                .Where(ap => ap.Id == id)
                .FirstOrDefault();

            user.IsDel = true;
            await dbContext.SaveChangesAsync(); 
        }

        public IEnumerable<ApplicationUserViewModel> GetApplicationUsers()
        {
            IEnumerable<ApplicationUserViewModel> appUsers = dbContext
                .ApplicationUsers
                .Where(ap => !ap.IsDel)
                .Select(ap => new ApplicationUserViewModel
                {
                    Id = ap.Id,
                    Name = ap.Name,
                });

            return appUsers;
        }
    }
}
