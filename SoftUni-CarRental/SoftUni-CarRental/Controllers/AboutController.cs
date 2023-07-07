using Microsoft.AspNetCore.Mvc;

namespace SoftUni_CarRental.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
