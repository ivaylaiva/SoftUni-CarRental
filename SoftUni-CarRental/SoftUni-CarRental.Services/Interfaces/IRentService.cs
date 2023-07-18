using SoftUni_CarRental.ViewModels.Car.FormModel;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface IRentService
    {
        Task<CarCardFormViewModel> GetForDetailsById(int carCardId);
    }
}
