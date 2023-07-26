using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Message;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class MessageServiceTests
    {
        [Test]
        public async Task AddMessageAsyncTest()
        {
            var db = ContextGenerator.Instance;

            var messageService = new MessageService(db);

            var messageTest = new MessageFormViewModel
            {
                FirstName = "Ivayla",
                LastName = "Emilova",
                UserEmail = "ivka@abv.bg",
                Description = "This is test description for messages.",
                
            };
            await messageService
                 .AddMessageAsync(messageTest);


            Assert.AreEqual(1, await db.Messages.CountAsync());
        }
        [Test]
        public async Task GetAllMessagesTest()
        {
            var db = ContextGenerator.Instance;

            var messageService = new MessageService(db);

            
            for (int i = 0; i < 3; i++)
            {
                await db.Messages.AddAsync(
               new Models.Models.Message
               {
                   FirstName = "Ivayla",
                   LastName = "Emilova",
                   UserEmail = "ivka@abv.bg",
                   Description = "This is test description for messages.",
               });
            }

            await db.SaveChangesAsync();
            var result = messageService.GetAllMessages();

            Assert.AreEqual(3, result.Count());
        }
    }
}
