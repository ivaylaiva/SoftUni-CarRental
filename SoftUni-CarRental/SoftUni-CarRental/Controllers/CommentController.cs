using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Comment;
using SoftUni_CarRental.ViewModels.Testimonials;

namespace SoftUni_CarRental.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await this.commentService.CreateCommentAsync(model);

            var testimonialsViewModel = new TestimonialsPageViewModel()
            {
                AllComments = this.commentService.GetAllComments()
            };

            return View("~/Views/Testimonials/Index.cshtml",testimonialsViewModel);
        }
    }
}
