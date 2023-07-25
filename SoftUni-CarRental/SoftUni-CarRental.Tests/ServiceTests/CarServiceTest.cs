using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;
using Xunit;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class CarServiceTest
    {
        [Test]
        public async Task AddCarAsyncTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);

            var carTest = new CarFormModel
            {
                Model = "Audi",
                DoorsCount = 4,
                Description = "This is fake description",
                Colour = "black",
                PassengersCount = 4,
                ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                PricePerDay = 200,
                ButtonLabel = "Rent Now"
            };
            await carService
                 .AddCarAsync(carTest);


            Assert.AreEqual(1, await db.Cars.CountAsync());
        }
        [Test]
        public async Task EditCarByIdTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);

            await db.Cars.AddAsync(
               new Models.Models.Car
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
               });
            await db.SaveChangesAsync();

            var modelToEdit = new EditCarViewModel
            {
                Model = "Fiat",
                Colour = "Red",
                Description = "this is test description",
                PricePerDay = 400,
                ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200",
                PassengersCount = 3,
                DoorsCount = 4
            };

            await carService.EditCarById(1, modelToEdit);

            var car = await db.Cars.FirstOrDefaultAsync();

            Assert.AreEqual(modelToEdit.Model, car.Model);
            Assert.AreEqual(modelToEdit.Colour, car.Colour);
            Assert.AreEqual(modelToEdit.Description, car.Description);
            Assert.AreEqual(modelToEdit.PricePerDay, car.PricePerDay);
            Assert.AreEqual(modelToEdit.ImageUrl, car.ImageUrl);
            Assert.AreEqual(modelToEdit.PassengersCount, car.PassengersCount);
            Assert.AreEqual(modelToEdit.DoorsCount, car.DoorsCount);
        }
        [Test]
        public async Task GetIdForEditTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);

            await db.Cars.AddAsync(
               new Models.Models.Car
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
               });
            await db.SaveChangesAsync();

            var model = await carService.GetIdForEdit(1);
            var car = await db.Cars.FirstOrDefaultAsync();

            Assert.AreEqual(model.Model, car.Model);
            Assert.AreEqual(model.Colour, car.Colour);
            Assert.AreEqual(model.Description, car.Description);
            Assert.AreEqual(model.PricePerDay, car.PricePerDay);
            Assert.AreEqual(model.ImageUrl, car.ImageUrl);
            Assert.AreEqual(model.PassengersCount, car.PassengersCount);
            Assert.AreEqual(model.DoorsCount, car.DoorsCount);
        }
        [Test]
        public async Task GetForDetailsByIdTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);

            await db.Cars.AddAsync(
               new Models.Models.Car
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
               });
            await db.SaveChangesAsync();

            var model = await carService.GetForDetailsById(1);
            var car = await db.Cars.FirstOrDefaultAsync();

            Assert.AreEqual(model.Model, car.Model);
            Assert.AreEqual(model.Colour, car.Colour);
            Assert.AreEqual(model.Description, car.Description);
            Assert.AreEqual(model.PricePerDay, car.PricePerDay);
            Assert.AreEqual(model.PassengersCount, car.PassengersCount);
            Assert.AreEqual(model.DoorsCount, car.DoorsCount);
            Assert.AreEqual(model.Id, car.Id);
        }
        [Test]
        public async Task AllAsyncTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);
            for (int i = 0; i < 3; i++)
            {
                await db.Cars.AddAsync(
               new Models.Models.Car
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
               });
            }

            await db.SaveChangesAsync();
            var result = await carService.AllAsync();

            Assert.AreEqual(3, result.Count());
        }
        [Test]
        public async Task DeleteByIdTest()
        {
            var db = ContextGenerator.Instance;

            var carCardService = new CarCardService(db);

            var carService = new CarService(db, carCardService);

            await db.Cars.AddAsync(
               new Models.Models.Car
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
               });
            await db.SaveChangesAsync();

            await carService.DeleteById(1);
            var car = await db.Cars.FirstOrDefaultAsync();

            Assert.AreEqual("Audi", car.Model);
            Assert.AreEqual(4, car.DoorsCount);
            Assert.AreEqual("This is fake description", car.Description);
            Assert.AreEqual("black", car.Colour);
            Assert.AreEqual(4, car.PassengersCount);
            Assert.AreEqual("https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200", car.ImageUrl);
            Assert.AreEqual(200, car.PricePerDay);
            Assert.IsTrue(car.IsAvailable);
            Assert.IsTrue(car.IsDeleted);
        }

    }
}
