using MotMaintOnline4.InputModels.ApplicationUser;
using MotMaintOnline4.ViewModels.ApplicationUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.ApplicationUser
{
    public interface IApplicationUserService
    {
        IEnumerable<ApplicationUserViewModel> GetApplicationUsers();

        Task Create(ApplicationUserInputModel inputModel);

        Task Edit(ApplicationUserInputModel inputModel);

        Task Delete(int id);

        UserDetailsViewModel UserDetails(int id);
    }
}
