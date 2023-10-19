using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public
        ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Product>().ToTable("Product");
            // Seeding
            //category
            modelBuilder.Entity<Category>().HasData(new Category
            { CategoryId = 1,Name="Verktøy", Description = "Tool" });
            modelBuilder.Entity<Category>().HasData(new Category
            { CategoryId = 2, Name = "Kjøretøy", Description = "Vehicle" });
            modelBuilder.Entity<Category>().HasData(new Category
            { CategoryId = 3, Name = "Dagligvarer", Description = "DailyWare" });
            //manufacturer
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
            { ManufacturerId = 1, Name="EverythingShop",Description="Got everything", Address="TestAddress"});
            //product
            modelBuilder.Entity<Product>()
            .HasData(new Product{
                ProductId = 1,
                Name = "Hammer",
                Price = 121.50m,
                ManufacturerId = 1,
                CategoryId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m,ManufacturerId=1, CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 3, Name = "Volvo XC90", Price = 990000m, ManufacturerId = 1, CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 4, Name = "Volvo XC60", Price = 620000m, ManufacturerId = 1, CategoryId = 2 });
            modelBuilder.Entity<Product>()
            .HasData(new Product{
                ProductId = 5,
                Name = "Brød",
                Price = 25.50m,
                ManufacturerId = 1,
                CategoryId = 3
            });
        }
    }
}
