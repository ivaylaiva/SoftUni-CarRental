using System.ComponentModel.DataAnnotations;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Car;

namespace SoftUni_CarRental.ViewModels;

public class CarFormModel
{
    [Required]
    [StringLength(MaxModelLength,MinimumLength =MinModelLength,ErrorMessage = "The model must be between 5 and 50 characters long!")]
    public string Model { get; set; } = null!;
    [Required]
    public decimal PricePerDay { get; set; }
    [Required]
    public int DoorsCount { get; set; }
    [Required]
    public int PassengersCount { get; set; }
    [Required]
    [StringLength(MaxColourLength, MinimumLength = MinColourLength, ErrorMessage = "The colour must be between 3 and 50 characters long!")]
    public string Colour { get; set; } = null!;
    [Required]
    [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = "The description must be between 10 and 1500 characters long!")]
    public string Description { get; set; } = null!;
    [Required]
    public string ImageUrl { get; set; } = null!;
    [Required]
    public string ButtonLabel { get; set; } = null!;
    //public int PhotoId { get; set; }
}
