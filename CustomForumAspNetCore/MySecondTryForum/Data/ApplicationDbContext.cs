using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySecondTryForum.Models;

namespace MySecondTryForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(ap => ap.Comments)
                .HasForeignKey(c => c.ApplicationUserId);

            builder.Entity<Comment>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TopicId);

            builder.Entity<Topic>()
                .HasOne(t => t.ApplicatuinUser)
                .WithMany(ap => ap.Topics)
                .HasForeignKey(t => t.ApplicationUserId);
        }
    }
}
