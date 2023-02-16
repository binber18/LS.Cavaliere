using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Dogs;
using LS.Cavaliere.Models.Requests.Files;
using LS.Cavaliere.Repositories;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.Services.Implementations;

internal class DogService : IDogService
{
    private readonly IInternalFileService _fileService;
    private readonly ILogger<DogService> _logger;
    private readonly IDogRepository _dogRepository;
    public DogService(IDogRepository dogRepository, IInternalFileService fileService, ILogger<DogService> logger)
    {
        _fileService = fileService;
        _logger = logger;
        _dogRepository = dogRepository;

    }

    public async Task<IEnumerable<Dog>> GetAllDogsAsync()
    {
        _logger.LogTrace("Getting all dogs");
        return await _dogRepository.GetAllDogsAsync();
    }
    public async Task<Guid> CreateDogAsync(CreateDogRequest createDogRequest)
    {
        var existingDog = await _dogRepository.GetDogByNameAsync(createDogRequest.Name);

        if (existingDog != null)
            return Guid.Empty;

        var fileRecord = FileRecord.FromFile(createDogRequest.Image.FileName, createDogRequest.Image.ContentType, createDogRequest.Name);

        var dog = new Dog
        {
            Id = Guid.NewGuid(),
            Name = createDogRequest.Name,
            BirthDay = createDogRequest.Birthday,
            Father = createDogRequest.Father,
            Mother = createDogRequest.Mother,
            Description = createDogRequest.Description,
            TitleImage = fileRecord.Id,
        };

        _logger.LogTrace("Creating dog {@Dog}", dog);

        if (!await _dogRepository.CreateDogAsync(dog))
            return Guid.Empty;

        await _fileService.SaveDogImageAsync(dog.Id, fileRecord.Id, createDogRequest.Image.Content, createDogRequest.Image.ContentType);

        return dog.Id;
    }
    public async Task<Dog?> GetByIdAsync(Guid id)
    {
        _logger.LogTrace("Getting dog with id {Id}", id);
        return await _dogRepository.GetByIdAsync(id);
    }
    public async Task UpdateDogAsync(Guid id, UpdateDogRequest updateDogRequest)
    {
        _logger.LogTrace("Updating dog with id {Id} with {@UpdateDogRequest}", id, updateDogRequest);
        if (id != updateDogRequest.Id)
            throw new ArgumentException("Id in request does not match id in route");
        await _dogRepository.UpdateDogAsync(id, updateDogRequest);
    }
    public async Task AddImageToDogAsync(Guid id, FileRequest request)
    {
        _logger.LogTrace("Adding image to dog with id {Id}", id);
        var dog = await _dogRepository.GetByIdAsync(id);
        if (dog is null)
        {
            _logger.LogWarning("Dog with id {Id} not found", id);
            return;
        }
        var record = request.ToFileRecord();
        await _fileService.SaveDogImageAsync(dog.Id, record.Id, request.Content, request.ContentType);
    }
    public async Task<bool> RemoveImageFromDogAsync(Guid dogId, string fileName)
    {
        _logger.LogTrace("Removing image {FileName} from dog with id {Id}", fileName, dogId);
        return await _fileService.DeleteDogImageAsync(dogId, fileName);
    }
    public async Task<IEnumerable<string>> GetImagesForDogAsync(Guid dogId)
    {
        _logger.LogTrace("Getting images for dog with id {Id}", dogId);
        return await _fileService.GetDogImagesAsync(dogId);
    }
    public async Task<string?> GetTitleImageForDogAsync(Guid dogId)
    {
        _logger.LogTrace("Getting title image for dog with id {Id}", dogId);
        var dog = await _dogRepository.GetByIdAsync(dogId);
        if (dog is null)
        {
            _logger.LogWarning("Dog with id {Id} not found", dogId);
            return null;
        }
        if (dog.TitleImage is not null)
            return dog.TitleImage;

        return await _fileService.GetFirstImageAsync(dogId);
    }
    public async Task SetTitleImageForDogAsync(Guid dogId, string fileName)
    {
        _logger.LogTrace("Setting title image {FileName} for dog with id {Id}", fileName, dogId);
        await _dogRepository.SetTitleImageForDogAsync(dogId, fileName);
    }
}