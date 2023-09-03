using AnimalApi.Data;
using AnimalApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AnimalApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private AnimalContext _context;



        public AnimalRepository(AnimalContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAnimalToDb(Animal animal)
        {
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();

            if (_context.Animals.Contains(animal)) return true;
            return false;
        }

        public async Task<bool> AddComment(string comment, int animalId)
        {
            Comment animalComment = new Comment  { AnimalId = animalId, Note = comment };
            await _context.Comments.AddAsync(animalComment);
            await _context.SaveChangesAsync();

            if(_context.Comments.Contains(animalComment)) return true;
            return false;
        }

        //Return All Animals 
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        //Return All Animals that match certain Category
        public async Task<IEnumerable<Animal>> GetAnimals(int categoryId)
        {
            return await _context.Animals.Where(a => a.CategoryId == categoryId).ToListAsync();
        }




        //Return all categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        //Return animal / null if no such animal exist
        public async Task<Animal> GetAnimalById(int animalId)
        {
            var animal = await _context.Animals.Where(animal => animal.AnimalId == animalId).SingleOrDefaultAsync();
            if (animal == null)
            {
                throw new KeyNotFoundException("No Animal With Given Id Found");
            }

            else return animal;
        }

        public async Task<IEnumerable<Animal>> GetTop2Animals()
        {
            return await _context.Animals.OrderByDescending(animal => animal.Comment!.Count()).Take(2).ToListAsync();

        }

        //Remove all Comments binded to that animal , then remove the animal 
        public async Task<bool> RemoveAnimalFromDb(int id)
        {
            //Check if animal exist , if not , do not proceed
            if (await GetAnimalById(id) is null)
            {
                return false;
            }

            await DeleteComments(id);


            var animal = await _context.Animals.Where(a => a.AnimalId == id).SingleAsync();


            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            if (_context.Animals.Contains(animal)) return false;
            return true;


        }

        //Helper method to delete comments of an animal
        private async Task DeleteComments(int animalId)
        {
            var comments = _context.Comments.Where(comment => comment.AnimalId == animalId);


            foreach (var comment in comments)
            {
                _context.Comments.Remove(comment);

            }

            await _context.SaveChangesAsync();
        }





        public async Task<bool> UpdateAnimalDetails(Animal inputAnimal)
        {
            var foundAnimal = await _context.Animals.Where(animal => animal.AnimalId == inputAnimal.AnimalId).SingleOrDefaultAsync();



            if (foundAnimal == null) return false;

            foundAnimal.Name = inputAnimal.Name;
            foundAnimal.Age = inputAnimal.Age;
            foundAnimal.CategoryId = inputAnimal.CategoryId;
            foundAnimal.Description = inputAnimal.Description;
            foundAnimal.PictureName = inputAnimal.PictureName;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByAnimal(int animalId)
        {
            return await _context.Comments.Where(c => c.AnimalId == animalId).ToListAsync();
        }
    }
}
