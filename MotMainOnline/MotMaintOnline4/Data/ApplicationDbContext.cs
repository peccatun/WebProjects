using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotMaintOnline4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotMaintOnline4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(ap => ap.Motorcycles)
                .WithOne(m => m.ApplicationUser);

            builder.Entity<ApplicationUser>()
                .HasMany(ap => ap.Maintenances)
                .WithOne(m => m.ApplicationUser);

            builder.Entity<Motorcycle>()
                .HasMany(m => m.Maintenances)
                .WithOne(m => m.Motorcycle);

            builder.Entity<Maintenance>()
                .HasOne(m => m.MaintenanceType)
                .WithOne(mt => mt.Maintenance);
                
                
        }
    }
}
