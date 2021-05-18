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

        public DbSet<CategoryImage> CategoryImages { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }



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
                .HasOne(c => c.CategoryImage)
                .WithOne(c => c.Category)
                .HasForeignKey<Category>(c => c.CategoryImageId);

            builder.Entity<Product>()
                .HasOne(p => p.ProductImage)
                .WithOne(pc => pc.Product)
                .HasForeignKey<ProductImage>(pc => pc.ProductId);
        }
    }
}
