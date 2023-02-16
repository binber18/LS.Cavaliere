using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Dogs;
using LS.Cavaliere.Models.Requests.Files;

namespace LS.Cavaliere.Services;

public interface IDogService
{
    Task<IEnumerable<Dog>> GetAllDogsAsync();
    Task<Guid> CreateDogAsync(CreateDogRequest createDogRequest);
    Task<Dog?> GetByIdAsync(Guid id);
    Task UpdateDogAsync(Guid id, UpdateDogRequest updateDogRequest);
    Task AddImageToDogAsync(Guid id, FileRequest request);
    Task<bool> RemoveImageFromDogAsync(Guid dogId, string fileName);
    Task<IEnumerable<string>> GetImagesForDogAsync(Guid dogId);
    Task<string?> GetTitleImageForDogAsync(Guid dogId);
    Task SetTitleImageForDogAsync(Guid dogId, string fileName);
}