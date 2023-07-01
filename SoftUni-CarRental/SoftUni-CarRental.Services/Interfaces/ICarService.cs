using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICarService
    {
        Task AddCarAsync(CarFormModel carModel);
        Task<IEnumerable<AllCarsViewModel>> AllAsync();
    }
}
