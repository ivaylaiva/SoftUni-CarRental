using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;
using SoftUni_CarRental.ViewModels.Comment;

namespace SoftUni_CarRental.Models.Home.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<AllCarCardViewModel> AllCarCards { get; set; }
        public IEnumerable<string> AllCarsForSearch { get; set; }
        public IEnumerable<AllCommentViewModel> AllComments { get; set; }

    }
}
