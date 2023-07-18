using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Services
{
    public class RentService : IRentService
    {
        private readonly CarRentalDbContext dbContext;
        public RentService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<CarCardFormViewModel> GetForDetailsById(int carCardId)
        {
            Car car = await this.dbContext
                 .Cars
                 .FindAsync(carCardId);

            CarCardFormViewModel model = await this.dbContext
               .CarCards
               .Select(c => new CarCardFormViewModel
               {
                   ButtonLabel = c.ButtonLabel,
                   CarId = car.Id,
                   Car = car
               })
               .FirstAsync(t => t.CarId == carCardId);

            return model;
        }
    }
}
