using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Car.FormModel;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Services
{
    public class CarCardService : ICarCardService
    {
        private readonly CarRentalDbContext dbContext;
        public CarCardService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateCarCard(CarCardFormViewModel carcardmodel)
        {
            var carCard = new CarCard
            {
                ButtonLabel = carcardmodel.ButtonLabel,
                CarId = carcardmodel.CarId,
            };
            await this.dbContext.AddAsync(carCard);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarCard(int id)
        {
            var carCard = dbContext.CarCards.Find(id);
            dbContext.CarCards.Remove(carCard);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCarCardViewModel>> GetAllCarCards()
        {
            return await this.dbContext
                 .CarCards
                 .Select(c => new AllCarCardViewModel()
                 {
                     ButtonLabel = c.ButtonLabel,
                     CarId = c.CarId,
                 })
                 .ToListAsync();
        }
    }
}
