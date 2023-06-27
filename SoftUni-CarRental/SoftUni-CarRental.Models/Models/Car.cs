using SoftUni_CarRental.Models.Abstraction;

namespace SoftUni_CarRental.Models.Models
{
    public class Car : EntityAbstraction
    {

        public string Model { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public int DoorsCount { get; set; }
        public int PassengersCount { get; set; }
        public string Colour { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
