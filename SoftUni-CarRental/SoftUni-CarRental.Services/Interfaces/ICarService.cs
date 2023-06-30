using SoftUni_CarRental.ViewModels;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICarService
    {
        Task AddCarAsync(CarFormModel carModel);
    }
}
