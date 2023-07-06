using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Comment;

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
            return RedirectToAction("~/Views/Testimonials/Index.cshtml");
        }
    }
}
