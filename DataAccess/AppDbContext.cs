using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
