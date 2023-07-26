using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;
using Car = SoftUni_CarRental.Models.Models.Car;
using CarCard = SoftUni_CarRental.Models.Models.CarCard;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class RentServiceTests
    {
        [Test]
        public async Task AddUserCarToCollectionTest()
        {
            var db = ContextGenerator.Instance;

            var rentService = new RentService(db);

            User user = new User()
            {
                UserName = "Test",
                Email = "Test@abv.bg"
            };
            db.Users.Add(user);

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

            var carCard = new CarCard
            {
                ButtonLabel = "RentNow",
                Car = car,
                CarId = car.Id,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            db.CarCards.Add(carCard);

            var userCarRent = new UserRentCar()
            {
                RentedOn = DateTime.Now,
                IsDeleted = false,
                User = user,
                UserId = user.Id,
                CarCardId = carCard.Id,
                CarCard = carCard
            };
            await db.SaveChangesAsync();
            await rentService
                 .AddUserCarToCollection(user,1);

            Assert.AreEqual(1, await db.UserRentCars.CountAsync());

        }
        [Test]
        public async Task RemoveFromUserCollectionTest()
        {
            var db = ContextGenerator.Instance;

            var rentService = new RentService(db);

            User user = new User()
            {
                UserName = "Test",
                Email = "Test@abv.bg"
            };
            db.Users.Add(user);

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

            var carCard = new CarCard
            {
                ButtonLabel = "RentNow",
                Car = car,
                CarId = car.Id,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            db.CarCards.Add(carCard);

            var userCarRent = new UserRentCar()
            {
                RentedOn = DateTime.Now,
                IsDeleted = false,
                User = user,
                UserId = user.Id,
                CarCardId = carCard.Id,
                CarCard = carCard
            };
            db.UserRentCars.Add(userCarRent);
            await db.SaveChangesAsync();

            await rentService.RemoveFromUserCollection(user,1);

            Assert.AreEqual(0, await db.UserRentCars.CountAsync());
        }
        [Test]
        public async Task GetAllCarCardForUserTest()
        {
            var db = ContextGenerator.Instance;

            var rentService = new RentService(db);

            User user = new User()
            {
                UserName = "Test",
                Email = "Test@abv.bg"
            };
            db.Users.Add(user);
            for (int i = 0; i < 2; i++)
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
                var carCard = new CarCard
                {
                    ButtonLabel = "RentNow",
                    Car = car,
                    CarId = car.Id,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                };
                db.CarCards.Add(carCard);
                var userCarRent = new UserRentCar()
                {
                    RentedOn = DateTime.Now,
                    IsDeleted = false,
                    User = user,
                    UserId = user.Id,
                    CarCardId = carCard.Id,
                    CarCard = carCard
                };
                db.UserRentCars.Add(userCarRent);
            }
            await db.SaveChangesAsync();
            
            var result =  rentService.GetAllCarCardForUser(user);

            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task GetForDetailsByIdTest()
        {
            var db = ContextGenerator.Instance;

            var rentService = new RentService(db);


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

            var carCard = new CarCard
            {
                ButtonLabel = "RentNow",
                Car = car,
                CarId = car.Id,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            db.CarCards.Add(carCard);

            await db.SaveChangesAsync();

            var model = await rentService.GetForDetailsById(1);
            var carCardTest = await db.CarCards.FirstOrDefaultAsync();

            Assert.AreEqual(model.ButtonLabel, carCardTest.ButtonLabel);
            Assert.AreEqual(model.Car, carCardTest.Car);
            Assert.AreEqual(model.CarId, carCardTest.CarId);
           
        }
    }
}
