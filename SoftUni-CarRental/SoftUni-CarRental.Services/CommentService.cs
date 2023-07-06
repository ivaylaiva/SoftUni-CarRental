using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Comment;

namespace SoftUni_CarRental.Services
{
    public class CommentService : ICommentService
    {
        private readonly CarRentalDbContext dbContext;
        public CommentService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateCommentAsync(CreateCommentViewModel model)
        {
            Comment comment = new Comment
            {
                Description = model.Description,
                UserEmail = model.UserEmail,
                CreatedOn = DateTime.Now,
            };
            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
