using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyEnvironment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //TODO: Configure DbContext and override ApplicationUser

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
