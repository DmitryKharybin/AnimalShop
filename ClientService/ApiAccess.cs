using ClientService.ModelDto;
using System.Net.Http.Json;

namespace ClientService
{
    public class ApiAccess : IApiAccess
    {
        HttpClient _httpClient;

        public ApiAccess()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5298/");
        }

        public async Task<bool> AddAnimal(AnimalDto animal)
        {
            var response = await _httpClient.PostAsJsonAsync<AnimalDto>("api/Shop", animal);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddComment(string comment, int animalId)
        {
            var response = await _httpClient.PostAsJsonAsync<CommentDto>("api/Shop/AddComment", new CommentDto { AnimalId = animalId, Note = comment });

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAnimal(int animalId)
        {
            var response = await _httpClient.DeleteAsync($"api/Shop/{animalId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<AnimalDto> GetAnimalById(int animalId)
        {
            var animal = await _httpClient.GetFromJsonAsync<AnimalDto>($"api/Shop/GetAnimalById/{animalId}");

            return animal;
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimals()
        {
            var animals = await _httpClient.GetFromJsonAsync<IEnumerable<AnimalDto>>("api/Shop/GetAnimals");
            return animals;
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimals(int categoryId)
        {
            var animals = await _httpClient.GetFromJsonAsync<IEnumerable<AnimalDto>>($"api/Shop/{categoryId}");
            return animals;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/Shop/GetCategories");
            return categories;
        }

        public async Task<IEnumerable<AnimalDto>> GetTop2Animal()
        {
            var animals = await _httpClient.GetFromJsonAsync<IEnumerable<AnimalDto>>("api/Shop");
            return animals;
        }

        public async Task<bool> UpdateAnimal(AnimalDto animal)
        {
            var response = await _httpClient.PutAsJsonAsync<AnimalDto>("api/Shop",animal);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}