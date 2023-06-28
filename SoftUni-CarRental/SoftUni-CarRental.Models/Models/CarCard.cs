using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.CarCard;

namespace SoftUni_CarRental.Models.Models
{
    public class CarCard : EntityAbstraction
    {
        [Required]
        [MaxLength(MaxButtonLabelLength)]
        public string ButtonLabel { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
