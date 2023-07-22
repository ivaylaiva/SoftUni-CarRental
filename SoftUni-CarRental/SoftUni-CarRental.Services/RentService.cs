using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;
using SoftUni_CarRental.ViewModels.Comment;
using SoftUni_CarRental.ViewModels.Rent;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants;
using Car = SoftUni_CarRental.Models.Models.Car;
using CarCard = SoftUni_CarRental.Models.Models.CarCard;

namespace SoftUni_CarRental.Services
{
    public class RentService : IRentService
    {
        private readonly CarRentalDbContext dbContext;
        public RentService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserCarToCollection(User user, int id)
        {
            Car car = await this.dbContext
                .Cars
                .FindAsync(id);

            CarCard carCard = await this.dbContext
                 .CarCards
                 .FirstAsync(x => x.Car.Id == car.Id);
                 

            UserRentCar userCarRent = new UserRentCar()
            {
                RentedOn = DateTime.Now,
                IsDeleted = false,
                User = user,
                UserId = user.Id,
                CarCardId = id,
                CarCard = carCard
            };
            CarRent carRent = new CarRent()
            {
                User = user,
                UserId = user.Id,
                RentedOn = DateTime.Now,
                IsDeleted = false,
            };

            car.IsAvailable = false;

            await this.dbContext.UserRentCars.AddAsync(userCarRent);
            await this.dbContext.CarRents.AddAsync(carRent);
            await dbContext.SaveChangesAsync();
        }
        public async Task RemoveFromUserCollection(User user, int id)
        {
            Car car = await this.dbContext
               .Cars
               .FindAsync(id);

            CarCard carCard = await this.dbContext
                 .CarCards
                 .FirstAsync(x => x.Car.Id == car.Id);

            UserRentCar userRentCar = await this.dbContext
                 .UserRentCars
                 .FirstAsync(x=>x.CarCardId == carCard.Id);

            car.IsAvailable = true;

            this.dbContext.UserRentCars.Remove(userRentCar);
            await this.dbContext.SaveChangesAsync();
        }
        public IEnumerable<AllCarCardViewModel> GetAllCarCardForUser(User user)
        {
            return this.dbContext
                .UserRentCars
                .Where(x=>x.User == user)
                .Select(c => new AllCarCardViewModel()
                {
                        ButtonLabel = c.CarCard.ButtonLabel,
                        Car = c.CarCard.Car,
                        CarId = c.CarCard.CarId,
                }) 
                .ToList();
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
