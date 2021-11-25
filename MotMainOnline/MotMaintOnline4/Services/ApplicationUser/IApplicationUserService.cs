using MotMaintOnline4.ViewModels.ApplicationUser;
using System.Collections.Generic;

namespace MotMaintOnline4.Services.ApplicationUser
{
    public interface IApplicationUserService
    {
        IEnumerable<ApplicationUserViewModel> GetApplicationUsers();
    }
}
