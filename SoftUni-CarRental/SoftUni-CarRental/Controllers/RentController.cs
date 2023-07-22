using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels.CarCard;
using SoftUni_CarRental.ViewModels.Rent;

namespace SoftUni_CarRental.Controllers
{
    public class RentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRentService rentService;
        public RentController(UserManager<User> userManager, SignInManager<User> signInManager
            , IRentService rentService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.rentService = rentService;
        }

        public async Task<IActionResult> MyRentedCars()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var allUserCarCards = new AllUserCarsViewModel
            {
                AllCarCards = this.rentService.GetAllCarCardForUser(user)
            };

            return View("RentNow", allUserCarCards);
        }


        public async Task<IActionResult> Index(int id)
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);

            //Това трябва да го оправим

            if (!_signInManager.IsSignedIn(User))
            {
                return View("~/Areas/Identity/Pages/Account/Login.cshtml");
            }

            CarCardFormViewModel model =
                    await this.rentService.GetForDetailsById(id);

            return View(model);
        }
        public async Task<IActionResult> RentNow(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }
            await this.rentService.AddUserCarToCollection(user, id);

            var allUserCarCards = new AllUserCarsViewModel
            {
                AllCarCards = this.rentService.GetAllCarCardForUser(user)
            };

            return View(allUserCarCards);
        }
        public async Task<IActionResult> ReleaseNow(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.rentService.RemoveFromUserCollection(user, id);

            var allUserCarCards = new AllUserCarsViewModel
            {
                AllCarCards = this.rentService.GetAllCarCardForUser(user)
            };

            return View("RentNow", allUserCarCards);
        }
    }
}




