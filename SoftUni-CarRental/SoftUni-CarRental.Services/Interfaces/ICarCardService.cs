using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICarCardService
    {
        Task CreateCarCard(CarCardFormViewModel carcardmodel);
        IEnumerable<AllCarCardViewModel> GetAllCarCards();
        Task DeleteCarCard(int id);
        Task <IEnumerable<AllCarCardViewModel>> SearchForCar(string model);
        Task<IEnumerable<string>> AllModels();
    }
}
