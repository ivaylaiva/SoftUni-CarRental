using Microsoft.AspNetCore.Mvc;

namespace SoftUni_CarRental.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
