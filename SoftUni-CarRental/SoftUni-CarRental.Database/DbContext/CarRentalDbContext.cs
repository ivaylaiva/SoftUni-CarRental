using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Data
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
    }
}