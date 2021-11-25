using MotMaintOnline4.Data;
using MotMaintOnline4.ViewModels.ApplicationUser;
using System.Linq;
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
