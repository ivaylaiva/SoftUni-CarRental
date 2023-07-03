namespace SoftUni_CarRental.ViewModels.CarCard
{
    public class AllCarCardViewModel
    {
        public string ButtonLabel { get; set; } = null!;
        public int CarId { get; set; }
        public SoftUni_CarRental.Models.Models.Car Car { get; set; }
    }
}
