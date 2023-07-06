using Microsoft.AspNetCore.Mvc;

namespace SoftUni_CarRental.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
