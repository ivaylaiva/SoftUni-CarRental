using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Listing;
using SoftUni_CarRental.ViewModels.Testimonials;

namespace SoftUni_CarRental.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly ICommentService commentService;
        public TestimonialsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public IActionResult Index()
        {
            var testimonialsViewModel = new TestimonialsPageViewModel()
            {
                AllComments = this.commentService.GetAllComments()
            };
            return View(testimonialsViewModel);
        }
        public IActionResult Index_Admin()
        {
            var testimonialsViewModel = new TestimonialsPageViewModel()
            {
                AllComments = this.commentService.GetAllComments()
            };
            return View(testimonialsViewModel);
        }

    }
}
