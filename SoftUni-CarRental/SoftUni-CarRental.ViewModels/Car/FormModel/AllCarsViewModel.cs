namespace SoftUni_CarRental.ViewModels.Car.FormModel
{
    public class AllCarsViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int DoorsCount { get; set; } 
        public int PassengersCount { get; set; }
        public string Colour { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
