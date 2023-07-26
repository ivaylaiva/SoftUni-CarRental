using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
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
                Car = carcardmodel.Car
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

        public  IEnumerable<AllCarCardViewModel> GetAllCarCards()
        {
            return this.dbContext
                 .CarCards
                 .Where(x=>x.Car.IsAvailable == true && x.Car.IsDeleted == false)
                 .Select(c => new AllCarCardViewModel()
                 {
                     ButtonLabel = c.ButtonLabel,
                     CarId = c.CarId,
                     Car = c.Car
                 })
                 .ToList();
        }

        public async Task<IEnumerable<AllCarCardViewModel>> SearchForCar(string model)
        {
            return await this.dbContext
                .CarCards
                .Where(x => x.Car.Model == model && x.Car.IsDeleted == false)
                .Select(x => new AllCarCardViewModel()
                {
                    ButtonLabel = x.ButtonLabel,
                    CarId = x.CarId,
                    Car = x.Car
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<string>> AllModels()
        {
            return await this.dbContext
                .CarCards
                .Where(x => x.Car.IsDeleted == false)
                .Select(x => new AllCarCardViewModel()
                {
                    ButtonLabel = x.ButtonLabel,
                    CarId = x.CarId,
                    Car = x.Car
                })
                .Select(x => x.Car.Model)
                .Distinct()
                .ToListAsync();
        }
    }
}
