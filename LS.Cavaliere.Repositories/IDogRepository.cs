using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Dogs;

namespace LS.Cavaliere.Repositories;

public interface IDogRepository
{
    Task<IEnumerable<Dog>> GetAllDogsAsync();
    Task<bool> CreateDogAsync(Dog dog);
    Task<Dog?> GetDogByNameAsync(string name);
    Task<Dog?> GetByIdAsync(Guid id);
    Task UpdateDogAsync(Guid id, UpdateDogRequest updateDogRequest);
    Task SetTitleImageForDogAsync(Guid dogId, string fileName);
}