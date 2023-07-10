using SoftUni_CarRental.ViewModels.Comment;
using SoftUni_CarRental.ViewModels.Message;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface IMessageService
    {
        Task AddMessageAsync(MessageFormViewModel model);
        IEnumerable<MessageFormViewModel> GetAllMessages();
    }
}
