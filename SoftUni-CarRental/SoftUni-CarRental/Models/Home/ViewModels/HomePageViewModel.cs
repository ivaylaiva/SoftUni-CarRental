using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.Models.Home.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<AllCarCardViewModel> AllCarCards { get; set; }
        public IEnumerable<string> AllCarsForSearch { get; set; }

    }
}
