using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Message;
using SoftUni_CarRental.ViewModels.Testimonials;

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
                return View();
            }
            await this.messageService.AddMessageAsync(model);
            return View();
        }
        public async Task<IActionResult> AllMessages()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var messagesPageViewModel = new AllMessagesViewModel()
            {
               AllMessages = this.messageService.GetAllMessages()
            };

            return View("~/Views/Contact/AllMessages.cshtml", messagesPageViewModel);
        }
    }

}

