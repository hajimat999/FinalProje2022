using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using FinallyFinalProject.Models.Base;

namespace FinallyFinalProject.DAL
{
    public class ApplicationDbContext :IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<DiscountAmount> discountAmounts { get; set; }
        public DbSet<BasketItem>BasketItems { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Wishlest> Wishlests { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                )
            {
                item.SetColumnType("decimal(6,2)");
            }

            modelBuilder.Entity<Category>()
               .HasIndex(c => c.CategoryName)
               .IsUnique();
            modelBuilder.Entity<Brand>()
              .HasIndex(c => c.BrandName)
              .IsUnique();
            modelBuilder.Entity<DiscountAmount>()
             .HasIndex(c => c.Amount)
             .IsUnique();
            modelBuilder.Entity<Information>()
            .HasIndex(c => c.Key)
            .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
