using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskReminder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
