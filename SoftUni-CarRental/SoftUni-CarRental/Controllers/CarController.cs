﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;

namespace SoftUni_CarRental.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController:Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }
           
           await this.carService.AddCarAsync(carModel);
           return RedirectToAction("GetAllCars");


        }
        public async Task<IActionResult> GetAllCars()
        {
            var model = await carService.AllAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                EditCarViewModel model = await this.carService
                    .GetIdForEdit(id);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("GetAllCars");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel editmodel,int id)
        {
            if(!ModelState.IsValid)
            {
                return View(editmodel);
            }
            try
            {
                await this.carService.EditCarById(id,editmodel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected Error while editing");
                return View(editmodel);
            }
            return RedirectToAction("GetAllCars");
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                DetailsCarViewModel model =
                    await this.carService.GetForDetailsById(id);
                return View(model);
            }
            catch (Exception)
            {
                return this.RedirectToAction("GetAllCars");
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await this.carService.DeleteById(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected Error while delete action");
                return View();
            }
            return RedirectToAction("GetAllCars");
        }
    }
}
