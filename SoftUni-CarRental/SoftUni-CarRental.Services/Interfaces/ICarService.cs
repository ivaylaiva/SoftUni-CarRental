using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICarService
    {
        Task AddCarAsync(CarFormModel carModel);
        Task<IEnumerable<AllCarsViewModel>> AllAsync();
        Task<EditCarViewModel> GetIdForEdit(int id);
        Task EditCarById(int id,EditCarViewModel model);
        Task<DetailsCarViewModel> GetForDetailsById(int id);
        Task DeleteById(int id);
    }
}
