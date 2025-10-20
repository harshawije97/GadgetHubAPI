using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User seeding
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                 Username = "harshawije99@gmail.com",
                 PasswordHash = "$2a$12$4REV67RRe3.fIhG0JO4NWeUJPepKfRf7.glbkgUhQHTYbUxOzgrw.",
                 Role = "Admin",
                 CreatedAt = new DateTime(2025, 10, 18, 0, 0, 0, DateTimeKind.Utc)
             },
             new User {
                 Id = Guid.Parse("b2c3d4e5-f6a7-4b6c-9d0e-1f2a3b4c5d6e"),
                 Username = "tharaka@gmail.com",
                 PasswordHash = "$2a$12$qnF0RsnxeTj3dYVLgdgv7.B7P8IF0yXM/9Lu1.b.Paysw4ZtwkmlS",
                 Role = "Customer",
                 CreatedAt = new DateTime(2025, 10, 18, 0, 0, 0, DateTimeKind.Utc)
             },
             new User {
                 Id = Guid.Parse("c3d4e5f6-a7b8-4c7d-0e1f-2a3b4c5d6e7f"),
                 Username = "mohommad@gmail.com",
                 PasswordHash = "$2a$12$D5uTShufk565QezoAawCJ.soJFTrLARV/aRDJ1Q0212pC6P0hGtGe",
                 Role = "Seller",
                 CreatedAt = new DateTime(2025, 10, 18, 0, 0, 0, DateTimeKind.Utc)
             });

            // Product seeding (example product)
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("885b3631-64f5-4c56-886b-ce4e492e3a53"),
                    Name = "Screwdriver Set 115 in 1 Magnetic Precision Tool Kit",
                    Description = "Upgrade your toolkit with the 115 in 1 Magnetic Screwdriver Set, a professional-grade precision tool kit designed for repairing electronics, gadgets, and household items. Whether you’re fixing a laptop, smartphone, gaming console, tablet, or camera, this all-in-one screwdriver kit provides every bit and accessory you’ll ever need.\r\n\r\nBuilt with high-quality chrome vanadium steel, this durable and corrosion-resistant set ensures long-lasting performance for both professionals and DIY enthusiasts.",
                    Category = "Accessories",
                    Price = 1990.99M,
                    CreatedAt = DateTime.UtcNow
                }
                );
        }
    }
}
