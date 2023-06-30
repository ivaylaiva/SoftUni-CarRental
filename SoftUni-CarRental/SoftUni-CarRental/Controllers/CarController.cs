using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Constants;
using SoftUni_CarRental.Models.Car.FormModel;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;

namespace SoftUni_CarRental.Controllers
{
    public class CarController:Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CarController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly ICarService carService;

        public CarController(ILogger<CarController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            await this..AddAsync(currentUserId, model);

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
            return RedirectToAction("All", "Board");
        }
    }
}
