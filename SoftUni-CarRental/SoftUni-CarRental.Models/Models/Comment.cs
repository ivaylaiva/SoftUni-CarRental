using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Comment;

namespace SoftUni_CarRental.Models.Models
{
    public class Comment : EntityAbstraction
    {
        [Required]
        [MaxLength(MaxDescriptionLengthForComment)]
        public string Description { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
    }
}
