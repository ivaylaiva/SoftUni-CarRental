﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Constants;
using SoftUni_CarRental.Models;
using SoftUni_CarRental.Models.Models;
using System.Diagnostics;

namespace SoftUni_CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if(_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var rolename = await _userManager.GetRolesAsync(user);

                if (rolename[0] == UserRoleConstants.Admin)
                {
                    return View("~/Views/Home/Index_Admin.cshtml");
                }
            }
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}