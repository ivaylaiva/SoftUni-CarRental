using SoftUni_CarRental.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftUni_CarRental.Models.Car.FormModel
{
    public class CarFormModel
    {
        public string Model { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public int DoorsCount { get; set; }
        public int PassengersCount { get; set; }
        public string Colour { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
