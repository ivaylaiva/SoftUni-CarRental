using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels;

namespace SoftUni_CarRental.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalDbContext dbContext;
        public CarService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddCarAsync(CarFormModel carModel)
        {
            Car car = new Car
            {
                Model = carModel.Model,
                DoorsCount = carModel.DoorsCount,
                Description = carModel.Description,
                Colour = carModel.Colour,
                CreatedOn = DateTime.Now,
                PassengersCount = carModel.PassengersCount,
                //PhotoId = carModel.PhotoId,
                PricePerDay = carModel.PricePerDay,
            };
            await this.dbContext.Cars.AddAsync(car);
            await this.dbContext.SaveChangesAsync();
        }
    }
    
}
