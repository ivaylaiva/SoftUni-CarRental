using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class CommentServiceTests
    {
        [Test]
        public async Task CreateCommentAsyncTest()
        {
            var db = ContextGenerator.Instance;

            var commentService = new CommentService(db);


            var commentTest = new CreateCommentViewModel
            {
                Description = "This is test description for test",
                UserEmail = "ivka@abv.bg",
            };
            await commentService
                 .CreateCommentAsync(commentTest);


            Assert.AreEqual(1, await db.Comments.CountAsync());
        }
        [Test]
        public async Task GetAllCommentsTest()
        {
            var db = ContextGenerator.Instance;

            var commentService = new CommentService(db);

            
            for (int i = 0; i < 3; i++)
            {
                await db.Comments.AddAsync(
               new Models.Models.Comment
               {
                   Description = "This is test description for test",
                   UserEmail = "ivka@abv.bg",
               });
            }

            await db.SaveChangesAsync();
            var result = commentService.GetAllComments();

            Assert.AreEqual(3, result.Count());
        }
    }
}
