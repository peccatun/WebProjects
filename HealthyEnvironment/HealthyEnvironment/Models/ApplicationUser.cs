using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Discussion> Discussions { get; set; } = new HashSet<Discussion>();

        public IEnumerable<Solution> Solutions { get; set; } = new HashSet<Solution>();

        public IEnumerable<Information> Information { get; set; } = new HashSet<Information>();

        public IEnumerable<Order> Orders { get; set; }
    }
}
