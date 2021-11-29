using MotMaintOnline4.ViewModels.Motorcycles;
using System.Collections.Generic;

namespace MotMaintOnline4.ViewModels.ApplicationUser
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MotorcycleViewModel> Motorcycles { get; set; }
    }
}
