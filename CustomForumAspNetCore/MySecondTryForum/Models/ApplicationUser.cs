using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace MySecondTryForum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Topic> Topics { get; set; } = new HashSet<Topic>();

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
