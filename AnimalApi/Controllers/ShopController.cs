using AnimalApi.Models;
using AnimalApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IAnimalRepository _animalRepository;

        public ShopController(IAnimalRepository repository, IWebHostEnvironment hostEnvironment)
        {
            _animalRepository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Animal>> GetTop2Animals()
        {
            var animals = await _animalRepository.GetTop2Animals();

            return animals;

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var animal = await _animalRepository.GetAnimals();
            return animal;
        }

        [HttpGet("{categoryId}")]
        public async Task<IEnumerable<Animal>> GetAnimals(int categoryId)
        {
            var animals = await _animalRepository.GetAnimals(categoryId);
            return animals;
        }

        [Route("[action]/{animalId}")]
        [HttpGet]
        public async Task<Animal> GetAnimalById(int animalId)
        {
            var animal = await _animalRepository.GetAnimalById(animalId);
            return animal;
        }


        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal animal)
        {
            if (!ModelState.IsValid) return BadRequest("Animal not valid");

            var response = await _animalRepository.AddAnimalToDb(animal);
            if (response) return StatusCode(201, animal);
            return BadRequest("Animal Not Added");

        }

        [HttpDelete("{animalId}")]
        public async Task<IActionResult> DeleteAnimal(int animalId)
        {
            var response = await _animalRepository.RemoveAnimalFromDb(animalId);

            if (response) return StatusCode(204);
            return BadRequest("Animal Not Deleted");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _animalRepository.GetCategories();
            return categories;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (!ModelState.IsValid) return BadRequest("Comment Not Valid");

            var response = await _animalRepository.AddComment(comment.Note, comment.AnimalId);

            if (response) return StatusCode(201, comment);
            return BadRequest("Comment Not Added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal(Animal animal)
        {
            if (!ModelState.IsValid) return BadRequest("Animal Not Updated");

            var response = await _animalRepository.UpdateAnimalDetails(animal);

            if (response) return StatusCode(200, animal);

            return BadRequest("Animal Not Updated");
        }



    }
}
