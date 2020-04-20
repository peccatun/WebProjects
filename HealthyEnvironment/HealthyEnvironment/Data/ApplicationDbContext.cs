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
        public DbSet<Category> Categories { get; set; }

        public DbSet<Discussion> Discussions { get; set; }

        public DbSet<Information> Information { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<Comment> Comments { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(c => c.Information)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            builder.Entity<Category>()
                .HasMany(c => c.Discussions)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId);

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Discussion>()
                .HasOne(d => d.ApplicationUser)
                .WithMany(a => a.Discussions)
                .HasForeignKey(d => d.ApplicationUserId);

            builder.Entity<Discussion>()
                .HasMany(d => d.Solutions)
                .WithOne(s => s.Discussion)
                .HasForeignKey(s => s.DiscussionId);

            builder.Entity<Information>()
                .HasOne(i => i.ApplicationUser)
                .WithMany(a => a.Information)
                .HasForeignKey(i => i.ApplicationUserId);

            builder.Entity<Order>()
                .HasOne(o => o.ApplicationUser)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.ApplicationUserId);

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);

            builder.Entity<Solution>()
                .HasOne(s => s.ApplicationUser)
                .WithMany(a => a.Solutions)
                .HasForeignKey(s => s.ApplicationUserId);

            builder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ApplicationUserId);

            builder.Entity<Information>()
                .HasMany(i => i.Comments)
                .WithOne(c => c.Information)
                .HasForeignKey(c => c.InformationId);
        }
    }
}
