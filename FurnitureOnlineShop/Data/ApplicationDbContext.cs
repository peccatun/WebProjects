using System;
using System.Collections.Generic;
using System.Text;
using FurnitureOnlineShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Color> Colors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<SubCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sb => sb.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(sb => sb.Products)
                .HasForeignKey(p => p.SubCategoryId);

            builder.Entity<Category>()
                .HasOne(c => c.Image)
                .WithOne(c => c.Category)
                .HasForeignKey<Category>(c => c.ImageId);

            builder.Entity<Product>()
                .HasOne(p => p.Image)
                .WithOne(pc => pc.Product)
                .HasForeignKey<Product>(pc => pc.ImageId);

            builder.Entity<Product>()
                .HasOne(p => p.Color)
                .WithOne(c => c.Product)
                .HasForeignKey<Product>(p => p.ColorId);
        }
    }
}
