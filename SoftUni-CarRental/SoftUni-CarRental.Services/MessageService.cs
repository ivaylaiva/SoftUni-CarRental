using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Message;

namespace SoftUni_CarRental.Services
{
    public class MessageService : IMessageService
    {
        private readonly CarRentalDbContext dbContext;
        public MessageService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddMessageAsync(MessageFormViewModel model)
        {
            Message message = new Message()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserEmail = model.UserEmail,
                Description = model.Description,
                CreatedOn = DateTime.Now,
            };
            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<MessageFormViewModel> GetAllMessages()
        {
            return this.dbContext
               .Messages
               .Select(c => new MessageFormViewModel()
               {
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Description = c.Description,
                   UserEmail = c.UserEmail,
               })
               .ToList();
        }
    }
}
