using AnimalShop.Filters;
using ClientService;
using ClientService.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShop.Controllers
{
    public class ShopController : Controller
    {

        private readonly IWebHostEnvironment _hostEnvironment;
        IApiAccess _apiAccess;


        public ShopController(IApiAccess apiAcces, IWebHostEnvironment hostEnvironment)
        {
            _apiAccess = apiAcces;
            _hostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        [TypeFilter(typeof(LoggerActionFilter))]
        public async Task<IActionResult> MainMenu()
        {
            var animal = await _apiAccess.GetTop2Animal();
            return View(animal);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Catalog()
        {
            ViewBag.Categories = await _apiAccess.GetCategories();
            var animal = await _apiAccess.GetAnimals();
            return View(animal);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Catalog(int categoryId)
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

        //Add Comment to animal
        //If Comment is not valid (empty) then Don't Add It

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AddComment(string Note, int animalId)
        {

            if (ModelState.IsValid)
            {
                await _apiAccess.AddComment(Note, animalId);
                return Ok();
            }

            return NotFound();

        }

    }
}
