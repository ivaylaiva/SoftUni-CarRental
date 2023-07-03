using SoftUni_CarRental.ViewModels.Car.FormModel;
using SoftUni_CarRental.ViewModels.CarCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICarCardService
    {
        Task CreateCarCard(CarCardFormViewModel carcardmodel);
        Task<IEnumerable<AllCarCardViewModel>> GetAllCarCards();
        Task DeleteCarCard(int id);
    }
}
