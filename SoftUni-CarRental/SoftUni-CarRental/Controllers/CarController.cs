using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;
using SoftUni_CarRental.ViewModels;
using SoftUni_CarRental.ViewModels.Car.FormModel;

namespace SoftUni_CarRental.Controllers
{

    public class CarController:Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CarController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly ICarService carService;

        public CarController(ILogger<CarController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager, ICarService carService)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
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

            //var random = new Random();
            //var photoName = random.Next();

            //var extension = updateExistingUserInformatio.Photo.FileName.Split(".").Last();
            //var fileName = $"{photoName}.{extension}";
            //var destPath = Path.Combine(_environment.WebRootPath, "images", fileName);

            //using (var fileStream = new FileStream(destPath, FileMode.Create))
            //{
            //    updateExistingUserInformatio.Photo.CopyTo(fileStream);
            //}

            //var memoryStream = new MemoryStream();
            //updateExistingUserInformatio.Photo.OpenReadStream().CopyTo(memoryStream);
            //byte[] photoAsBytes = memoryStream.ToArray();

            //var photoDTO = _mapper.Map<PhotoDTO>(updateExistingUserInformatio);
            //photoDTO.PhotoAsNumber = photoName;
            //photoDTO.Type = fileName;

            //photoDTO.PhotoAsBytes = photoAsBytes;
            //photoDTO.PhotoDescription = updateExistingUserInformatio.PhotoDescription;

            //userDTO.ProfilePhoto = fileName;
            //await _photoService.UploadPhotoAsync(0, int.Parse(_userManager.GetUserId(User)), photoDTO);

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
    }
}
