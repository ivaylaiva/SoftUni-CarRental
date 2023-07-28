using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalDbContext dbContext;
        private readonly ICarCardService cardService;

      
        public CarService(CarRentalDbContext dbContext, ICarCardService cardService)
        {
            this.dbContext = dbContext;
            this.cardService = cardService;
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
                ImageUrl = carModel.ImageUrl,
                PricePerDay = carModel.PricePerDay,
                IsAvailable = true,
                IsDeleted = false,
            };
            await this.dbContext.Cars.AddAsync(car);
            await this.dbContext.SaveChangesAsync();

            var carCardViewModel = new CarCardFormViewModel
            {
                ButtonLabel = carModel.ButtonLabel,
                CarId = car.Id,
                Car = car,
            };

            await this.cardService.CreateCarCard(carCardViewModel);
        }

        public async Task<IEnumerable<AllCarsViewModel>> AllAsync()
        {
            return await this.dbContext
               .Cars
               .Where(x=>x.IsDeleted == false)
               .Select(car => new AllCarsViewModel()
               {
                   Id = car.Id,
                   Model = car.Model,
                   DoorsCount = car.DoorsCount,
                   PassengersCount = car.PassengersCount,
                   ImageUrl = car.ImageUrl,
                   PricePerDay = car.PricePerDay,
                   Colour = car.Colour,
                   Description = car.Description,
               })
               .ToListAsync();
        }

        public async Task EditCarById(int id, EditCarViewModel model)
        {
            Car car = await this.dbContext
                .Cars
                .FindAsync(id);

            car.Model = model.Model;
            car.Colour = model.Colour;
            car.Description = model.Description;
            car.PricePerDay = model.PricePerDay;
            car.ImageUrl = model.ImageUrl;
            car.PassengersCount = model.PassengersCount;
            car.DoorsCount = model.DoorsCount;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<DetailsCarViewModel> GetForDetailsById(int id)
        {
            DetailsCarViewModel model = await this.dbContext
               .Cars
               .Select(c => new DetailsCarViewModel
               {
                  Id = c.Id,
                  Model = c.Model,
                  PassengersCount= c.PassengersCount,
                  PricePerDay= c.PricePerDay,
                  Colour = c.Colour,
                  Description = c.Description,
                  DoorsCount= c.DoorsCount,
                  CreatedOn= c.CreatedOn
               })
               .FirstAsync(t => t.Id == id);

            return model;
        }

        public async Task<EditCarViewModel> GetIdForEdit(int id)
        {
            Car car = await this.dbContext
                .Cars
                .FindAsync(id);

            return new EditCarViewModel()
            {
                Model = car.Model,
                DoorsCount = car.DoorsCount,
                Description = car.Description,
                PassengersCount = car.PassengersCount,
                PricePerDay = car.PricePerDay,
                Colour = car.Colour,
                ImageUrl = car.ImageUrl,
            };
        }
        public async Task DeleteById(int id)
        {
            var car = dbContext.Cars.Find(id);
            car.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }
    }
}
