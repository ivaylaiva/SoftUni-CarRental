using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.ViewModels.Car.FormModel;
using SoftUni_CarRental.ViewModels.CarCard;
using SoftUni_CarRental.ViewModels.Comment;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface IRentService
    {
        Task<CarCardFormViewModel> GetForDetailsById(int carCardId);
        Task AddUserCarToCollection(User user,int id);
        IEnumerable<AllCarCardViewModel> GetAllCarCardForUser(User user);
        Task RemoveFromUserCollection(User user, int id);
    }
}
