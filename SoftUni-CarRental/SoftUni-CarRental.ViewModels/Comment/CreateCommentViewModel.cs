using System.ComponentModel.DataAnnotations;
using static SoftUni_CarRental.Common.EntityValidations.EntityValidationConstants.Comment;

namespace SoftUni_CarRental.ViewModels.Comment
{
    public class CreateCommentViewModel
    {
        [Required]
        [StringLength(MaxDescriptionLengthForComment,MinimumLength =MinDescriptionLengthForComment,ErrorMessage = "The description must be between 10 and 1500 characters long!")]
        public string Description { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
    }
}
