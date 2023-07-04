using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Models.Home.ViewModels;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.Listing;

namespace SoftUni_CarRental.Controllers
{
    public class ListingController : Controller
    {
        private readonly ICarCardService _cardService;
        public ListingController(ICarCardService _cardService)
        {
            this._cardService = _cardService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listingpageViewModel = new ListingPageViewModel()
            {
                AllCarCardsForListing = this._cardService.GetAllCarCards()
            };
            return View(listingpageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Search(string model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Listing/Index.cshtml");
            }

            var listingpageViewModel = new ListingPageViewModel()
            {
                AllCarCardsForListing = await this._cardService.SearchForCar(model)
            };
            return View("~/Views/Listing/Index.cshtml",listingpageViewModel);
        }
    }
}
