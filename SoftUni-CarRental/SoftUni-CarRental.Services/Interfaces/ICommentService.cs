using SoftUni_CarRental.ViewModels.Comment;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentViewModel model);
    }
}
