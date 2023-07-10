using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Database
{
    public class CarRentalDbContext : IdentityDbContext<User, Role, string>
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarCard> CarCards { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}