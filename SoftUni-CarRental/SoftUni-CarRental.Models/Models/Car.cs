using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Car;

namespace SoftUni_CarRental.Models.Models
{
    public class Car : EntityAbstraction
    {
        public Car()
        {
            this.RentedCars = new HashSet<CarRent>();
        }
        [Required]
        [MaxLength(MaxModelLength)]
        public string Model { get; set; } = null!;

        [Required]
        public decimal PricePerDay { get; set; }

        [Required]
        public int DoorsCount { get; set; }

        [Required]
        public int PassengersCount { get; set; }

        [Required]  
        public string Colour { get; set; } = null!;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public bool IsAvailable { get; set; }

        public IEnumerable<CarRent> RentedCars { get; set; } = null!;
    }
}
