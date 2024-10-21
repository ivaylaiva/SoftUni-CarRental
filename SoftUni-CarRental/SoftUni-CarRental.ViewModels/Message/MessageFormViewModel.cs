using System.ComponentModel.DataAnnotations;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Message;

namespace SoftUni_CarRental.ViewModels.Message
{
    public class MessageFormViewModel
    {

        [Required]
        [StringLength(MaxFirstNameLength,MinimumLength =MinFirstNameLength,ErrorMessage = "The first name must be between 2 and 30 characters long!")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "The last name must be between 2 and 30 characters long!")]
        public string LastName { get; set; } = null!;

        [Required]
        public string UserEmail { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = "The description must be between 10 and 1500 characters long!")]
        public string Description { get; set; } = null!;
    }
}
