using ClientService.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public interface IApiAccess
    {
        Task<IEnumerable<AnimalDto>> GetTop2Animal();

        Task<IEnumerable<AnimalDto>> GetAnimals();

        Task<IEnumerable<AnimalDto>> GetAnimals(int categoryId);

        Task<IEnumerable<CategoryDto>> GetCategories();

        Task<AnimalDto> GetAnimalById(int animalId);

        Task<bool> AddAnimal(AnimalDto animal);

        Task<bool> DeleteAnimal(int animalId);

        Task<bool> AddComment(string comment, int animalId);

        Task<bool> UpdateAnimal(AnimalDto animal);
    }
}
