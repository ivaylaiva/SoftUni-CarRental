using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Message;

namespace SoftUni_CarRental.Models.Models
{
    public class Message : EntityAbstraction
    {
        [Required]
        [MaxLength(MaxFirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string UserEmail { get; set; } = null!;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;
    }
}
