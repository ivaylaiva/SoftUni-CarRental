using System.ComponentModel.DataAnnotations;

namespace SoftUni_CarRental.ViewModels.Message
{
    public class MessageFormViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string UserEmail { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
