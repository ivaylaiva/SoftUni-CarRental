using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;

namespace SoftUni_CarRental.Tests
{
    public static class ContextGenerator
    {
        public static CarRentalDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<CarRentalDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                return new CarRentalDbContext(options);
            }
        }
    }
}
