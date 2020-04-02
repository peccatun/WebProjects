using System;
using System.Collections.Generic;
using System.Text;
using HealthyEnvironment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyEnvironment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //TODO: Configure appsetings.json
        //TODO: Make dbSets
        //TODO: Configure IdentityDbContext<>
        //TODO: Override ApplicationUser

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
