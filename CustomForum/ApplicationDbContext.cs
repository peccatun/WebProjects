using CustomForum.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomForum
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer(@"Server=DESKTOP-OU2Q3NF\SQLEXPRESS;Database=MyForum;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Topics)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder
                .Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Topic>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Topic)
                .HasForeignKey(c => c.TopicId);
        }
    }
}
