using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<Discussion> Discussions { get; set; } = new HashSet<Discussion>();

        public virtual IEnumerable<Solution> Solutions { get; set; } = new HashSet<Solution>();

        public virtual IEnumerable<Information> Information { get; set; } = new HashSet<Information>();

        public virtual IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
