using AnimalShop.Services;
using ClientService;
using ClientService.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AnimalShop.Controllers
{
    public class AdministratorController : Controller
    {
        private IFileUpload _fileUpload;

        //private IAnimalRepository _animalRepository;
        IApiAccess _apiAccess;
        public AdministratorController(IApiAccess apiAccess, IFileUpload fileUpload)
        {
            _apiAccess = apiAccess;
            _fileUpload = fileUpload;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Administrator()
        {
            ViewBag.Categories = await _apiAccess.GetCategories();
            var animal = await _apiAccess.GetAnimals();
            return View(animal);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Administrator(int categoryId)
        {

            IEnumerable<AnimalDto> animal;

            if (categoryId == 0)
            {
                animal = await _apiAccess.GetAnimals();
            }

            else
            {
                animal = await _apiAccess.GetAnimals(categoryId);
            }
            ViewBag.Categories = await _apiAccess.GetCategories();
            return View(animal);
        }

        public async Task<IActionResult> ShowAnimalDetails(int animalId)
        {
            var animal = await _apiAccess.GetAnimalById(animalId);
            return View(animal);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> CreateAnimal()
        {
            ViewBag.Categories = await _apiAccess.GetCategories();
            return View();
        }



        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnimal(IFormFile pictureName, AnimalDto inputAnimal)
        {
            ModelState.Remove("PictureName");

            //If Any Of Animal properties don't pass the check , or no file uploaded , then return to create animal
            if (!ModelState.IsValid || pictureName == null)
            {
                TempData["createAnimalError"] = "Faild To Create Animal, Please Check your input and try again";
                return RedirectToAction("CreateAnimal");
            }

            await _fileUpload.UploadFileAsync(pictureName);


            inputAnimal.PictureName = pictureName.FileName;
            await _apiAccess.AddAnimal(inputAnimal);
            return RedirectToAction("Administrator");

        }

        [Authorize]
        public async Task<IActionResult> Delete(int animalId)
        {
            if (animalId != 0)
            {
                await _apiAccess.DeleteAnimal(animalId);
            }

            return RedirectToAction("Administrator");
        }

        [Authorize]
        public async Task<IActionResult> EditAnimal(int animalId)
        {
            ViewBag.Categories = await _apiAccess.GetCategories();
            AnimalDto animal = await _apiAccess.GetAnimalById(animalId);



            return View(animal);
        }



        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAnimal(IFormFile formFile, AnimalDto inputAnimal)
        {

            // Redirect Back To animal edit unless Picture name is null , That means That user choose not to change picture .

            if (!ModelState.IsValid)
            {
                //If only one error is present & the error is null formfile (User choose not to update picture) , proceed
                if (!(ModelState.ErrorCount == 1 && formFile == null))
                {
                    return RedirectToAction("EditAnimal", new { animalId = inputAnimal.AnimalId });
                }

            }

            //If no picture choosen , then leave current picture
            if (formFile != null)
            {
                await _fileUpload.UploadFileAsync(formFile);
                inputAnimal.PictureName = formFile.FileName;
            }

            await _apiAccess.UpdateAnimal(inputAnimal);

            return RedirectToAction("Administrator");
        }

    }
}
