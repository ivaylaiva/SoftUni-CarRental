using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Message;

namespace SoftUni_CarRental.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService messageService;
        public ContactController(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(MessageFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await this.messageService.AddMessageAsync(model);
            return RedirectToAction("Index");
        }
    } 
}
