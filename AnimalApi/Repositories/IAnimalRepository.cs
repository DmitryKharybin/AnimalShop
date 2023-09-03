using AnimalApi.Models;
using System.Xml.Linq;

namespace AnimalApi.Repositories
{
    public interface IAnimalRepository
    {
        //Will return top 2 animals ==> Measure by review count
        Task<IEnumerable<Animal>> GetTop2Animals();

        //Get All Animals / All Animals of specific category (1 overload)
        Task<IEnumerable<Animal>> GetAnimals();
        Task<IEnumerable<Animal>> GetAnimals(int categoryId);



        // Get The Res Of All 3 Tables ==> All Details of Specific Animal
        Task<Animal> GetAnimalById(int animalId);

        Task<bool> AddAnimalToDb(Animal animal);
        Task<bool> RemoveAnimalFromDb(int id);

        //List<string> GetCategories(); 
        Task<IEnumerable<Category>> GetCategories();

        Task<bool> AddComment(string comment, int animalId);

        

        //Comment GetComments(Animal animal);



        Task<bool> UpdateAnimalDetails(Animal inputAnimal);

        Task<IEnumerable<Comment>> GetCommentsByAnimal(int animalId);
    }
}
