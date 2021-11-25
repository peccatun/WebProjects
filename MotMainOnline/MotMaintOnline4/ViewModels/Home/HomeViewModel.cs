using MotMaintOnline4.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; } = new HashSet<ApplicationUserViewModel>();
    }
}
