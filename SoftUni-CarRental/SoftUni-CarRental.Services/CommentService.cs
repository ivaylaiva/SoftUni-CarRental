﻿using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;
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
                IsDeleted = false
            };
            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<AllCommentViewModel> GetAllComments()
        {
            return this.dbContext
                .Comments
                .Select(c => new AllCommentViewModel()
                {
                   Description= c.Description,
                   UserEmail= c.UserEmail,
                })
                .ToList();
        }
    }
}
