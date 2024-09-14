using MotMaintOnline4.InputModels.ApplicationUser;
using MotMaintOnline4.ViewModels.ApplicationUser;
using System.Collections.Generic;

namespace MotMaintOnline4.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; } = 
            new HashSet<ApplicationUserViewModel>();

        public ApplicationUserInputModel UserInputModel { get; set; }
    }
}
