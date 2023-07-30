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
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await this.commentService.DeleteById(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected Error while delete action");
                return View();
            }
            return RedirectToAction("Index_Admin");
        }

    }
}
