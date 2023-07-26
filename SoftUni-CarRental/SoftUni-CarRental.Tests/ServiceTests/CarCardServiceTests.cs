using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class CarCardServiceTests
    {
        [Test]
        public async Task CreateCarCardTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carCard = new CarCardFormViewModel
            {
                ButtonLabel = "RentNow",
                CarId = 1,
            };

            await carCardService
                 .CreateCarCard(carCard);

            Assert.AreEqual(1, await db.CarCards.CountAsync());
        }
        [Test]
        public async Task GetAllCarCardsTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);
            
            for (int i = 0; i < 3; i++)
            {
                var car = new Car
               {
                   Model = "Audi",
                   DoorsCount = 4,
                   Description = "This is fake description",
                   Colour = "black",
                   PassengersCount = 4,
                   ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                   PricePerDay = 200,
                   CreatedOn = DateTime.Now,
                   IsAvailable = true,
                   IsDeleted = false
               };
                db.Cars.Add(car);

                await db.CarCards.AddAsync(
              new CarCard
              {
                  ButtonLabel = "RentNow",
                  Car = car,
                  CarId = car.Id,
                  CreatedOn = DateTime.Now,
                  IsDeleted = false
              });
            }
            await db.SaveChangesAsync();
            var result = carCardService.GetAllCarCards();

            Assert.AreEqual(3, result.Count());

        }
        [Test]
        public async Task SearchForCarTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);
            string model = "Audi";

            for (int i = 0; i < 3; i++)
            {
                var car = new Car
                {
                    Model = "Audi",
                    DoorsCount = 4,
                    Description = "This is fake description",
                    Colour = "black",
                    PassengersCount = 4,
                    ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                    PricePerDay = 200,
                    CreatedOn = DateTime.Now,
                    IsAvailable = true,
                    IsDeleted = false
                };
                db.Cars.Add(car);

                await db.CarCards.AddAsync(
              new CarCard
              {
                  ButtonLabel = "RentNow",
                  Car = car,
                  CarId = car.Id,
                  CreatedOn = DateTime.Now,
                  IsDeleted = false
              });
            }
            await db.SaveChangesAsync();

            var result =await carCardService.SearchForCar(model);

            Assert.That(result.Count(), Is.EqualTo(3));
        }
        [Test]
        public async Task AllModelsTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);
           

            for (int i = 0; i < 3; i++)
            {
                var car = new Car
                {
                    Model = "Audi",
                    DoorsCount = 4,
                    Description = "This is fake description",
                    Colour = "black",
                    PassengersCount = 4,
                    ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                    PricePerDay = 200,
                    CreatedOn = DateTime.Now,
                    IsAvailable = true,
                    IsDeleted = false
                };
                db.Cars.Add(car);

                await db.CarCards.AddAsync(
              new CarCard
              {
                  ButtonLabel = "RentNow",
                  Car = car,
                  CarId = car.Id,
                  CreatedOn = DateTime.Now,
                  IsDeleted = false
              });
            }
            await db.SaveChangesAsync();

            var result = await carCardService.AllModels();

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteCarCardTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            for (int i = 0; i < 3; i++)
            {
                var car = new Car
                {
                    Model = "Audi",
                    DoorsCount = 4,
                    Description = "This is fake description",
                    Colour = "black",
                    PassengersCount = 4,
                    ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                    PricePerDay = 200,
                    CreatedOn = DateTime.Now,
                    IsAvailable = true,
                    IsDeleted = false
                };
                db.Cars.Add(car);

                await db.CarCards.AddAsync(
              new CarCard
              {
                  ButtonLabel = "RentNow",
                  Car = car,
                  CarId = car.Id,
                  CreatedOn = DateTime.Now,
                  IsDeleted = false
              });
            }
            await db.SaveChangesAsync();
            await carCardService.DeleteCarCard(1);

            Assert.That(db.CarCards.Count(), Is.EqualTo(2));
        }

    }
}
