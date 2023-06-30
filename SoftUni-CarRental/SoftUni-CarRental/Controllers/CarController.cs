using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni_CarRental.Constants;
using SoftUni_CarRental.Models.Car.FormModel;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Controllers
{
    public class CarController:Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CarController> _logger;
        private readonly SignInManager<User> _signInManager;

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
            //if (!ModelState.IsValid)
            //{
            //    model.allBoards = await this.boardService.SelectBoardAsync();
            //    return View(model);
            //}
            //bool existId = await this.boardService.ExistBoardById(model.BoardId);

            //string currentUserId = this.GetUserId();

            //if (!existId)
            //{
            //    model.allBoards = await this.boardService.SelectBoardAsync();
            //    ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
            //    return View(model);
            //}
            //await this.taskService.AddAsync(currentUserId, model);

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
