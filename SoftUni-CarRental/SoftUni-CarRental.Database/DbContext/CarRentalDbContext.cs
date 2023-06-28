using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Database
{
    public class CarRentalDbContext : IdentityDbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCard> CarCards { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "member",
                    NormalizedName = "MEMBER",
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "admin",
                    NormalizedName = "ADMIN",
                });

            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser admin = new IdentityUser
            {
                Id = "1",
                UserName = "admin@carrental.com",
                NormalizedUserName = "ADMIN@CARRENTAL.COM",
                Email = "admin@carrental.com",
                NormalizedEmail = "ADMIN@CARRENTAL.COM",
                SecurityStamp = "7I5VHIJTSZNOT3KDWKNFUV5PVYBHGXN",
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            base.OnModelCreating(modelBuilder);
        }
    }
}