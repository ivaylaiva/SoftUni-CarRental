﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Constants;
using SoftUni_CarRental.Models.Home.ViewModels;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels;
using System.Diagnostics;

namespace SoftUni_CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICarCardService _carCardService;
        private readonly ICommentService commentService;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager, ICarCardService carCardService, ICommentService commentService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._carCardService = carCardService;
            this.commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var homePageViewModel = new HomePageViewModel()
            {
                AllCarCards = this._carCardService.GetAllCarCards(),
                AllCarsForSearch = await this._carCardService.AllModels(),
                AllComments = this.commentService.GetAllComments()
            };

            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var rolename = await _userManager.GetRolesAsync(user);

                if (rolename[0] == UserRoleConstants.Admin)
                {
                    return View("~/Views/Home/Index_Admin.cshtml");
                }
                else
                {
                    return View("~/Views/Home/Index.cshtml", homePageViewModel);
                }
            }


            return View(homePageViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return this.View();
        }
    }
}